using UnityEngine;

namespace Game.Model
{
    public class PlayerMovement
    {
        public readonly InertMovement _inert;

        private readonly float _gravity = 9.8f;
        private readonly float _forceJumpe = 15;
        private readonly float _raycastLengh = 1.5f;
        private readonly float _speedRotate;
        private readonly float _speedMove;
        private readonly Player _player;

        private bool _isActiveAccalerate;
        private Vector3 _direction;
        private Vector2 _rotate;
        private Vector3 _slider;

        private bool _isActiveSitDown = false;

        public PlayerMovement(Player Player,InertMovement Inert, float Gravity, float ForceJumpe, float RaycastLengh, float SpeedRotate, float SpeedMove)
        {
            _player = Player;
            _inert = Inert;
            _gravity = Gravity;
            _forceJumpe = ForceJumpe;
            _raycastLengh = RaycastLengh;
            _speedRotate = SpeedRotate;
            _speedMove = SpeedMove;
        }

        public void Move(Vector2 direction)
        {
            if (_player.IsGrounded)
            {
                direction *= _speedMove;
                _direction = new Vector3(direction.x,_direction.y,direction.y);
            }
        }

        public void Jumpe()
        {
            if (_player.IsGrounded)
                _direction.y = _forceJumpe;
        }

        public void Update(float deltaTime)
        {
            if (_inert.Accaliration != 0)
            {
                _isActiveAccalerate = true;
                _direction.z += _inert.Accaliration;
            }
            else if (_isActiveAccalerate)
            {
                _isActiveAccalerate = false;
            }
            
            if(_player.IsGrounded && _direction.y < -Conffig.Gravity)
                _direction.y = -Conffig.Gravity;

            if (_player.IsGrounded == false)
                _direction.y -= _gravity * deltaTime;

            _player.Move((_direction + _slider) * deltaTime,_isActiveAccalerate,_isActiveSitDown);
            _player.Rotate(_rotate * deltaTime);
        }

        public void Rotate(Vector2 rotate) => _rotate = rotate * _speedRotate;

        public void FixedUpdete() => _slider = _player.Slider(_raycastLengh,_forceJumpe);

        public void SitDown()
        {
            if (_player.IsActiveAnimationSitDown)
                return;

            if (_isActiveSitDown == false)
                SitDownEnter();
            else 
                SitDownExit();
        }

        private void SitDownEnter()
        {
            _isActiveSitDown = true;
            _player.SitDownActive(true);
        }

        private void SitDownExit()
        {
            _isActiveSitDown = false;
            _player.SitDownActive(false);
        }

    }
}

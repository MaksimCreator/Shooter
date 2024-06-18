using System;
using UnityEngine;

namespace Game.Model
{
    public class Player : IPosition
    {
        private readonly CharacterController _playerController;
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly float _maxAngleCamera;

        private bool _isSitDown;
        private bool _isAccalerate = false;

        public Action<bool> OnAccalerate;
        public Action<bool> OnSitDown;

        public bool IsActiveAnimationSitDown { get; private set; }
        public Vector3 Position => _transform.position;
        public bool IsGrounded => _playerController.isGrounded;

        public Player(Camera Camera,CharacterController Controller, Transform Player, float MaxAngelCamera)
        {
            _transform = Player;
            _playerController = Controller;
            _camera = Camera;
            _maxAngleCamera = MaxAngelCamera;
        }

        public void Move(Vector3 direction,bool isAccaleration,bool isSitdown)
        {
            if (direction == Vector3.zero)
                return;

            if (isAccaleration)
            {
                if (_isAccalerate == false)
                {
                    _isAccalerate = true;
                    OnAccalerate?.Invoke(isAccaleration);
                }
            }
            else
            {
                if (_isAccalerate)
                {
                    _isAccalerate = false;
          //        OnAccalerate?.Invoke(isAccaleration);
                }
            }
       
            if (isSitdown)
                direction *= Conffig.SpeedSitDown;

            Vector3 directionMove = _transform.TransformDirection(direction);
            _playerController.Move(directionMove);
        }

        public Vector3 Slider(float raycastLength, float slopeForce)
        {
            Vector3 direction = Vector3.zero;

            if (Physics.Raycast(_transform.position, Vector3.down, out RaycastHit hit, raycastLength) == false)
                return direction;

            if (Vector3.Angle(hit.normal, Vector3.up) > _playerController.slopeLimit)
            {
                direction.x += (1f - hit.normal.y) * hit.normal.x * slopeForce;
                direction.z += (1f - hit.normal.y) * hit.normal.z * slopeForce;
                direction.y -= slopeForce;
            }

            return direction;
        }

        public void Rotate(Vector2 direcion)
        {
            if (direcion == Vector2.zero)
                return;

            if (direcion.x != 0)
            {
                float PlayerRotate = Mathf.Repeat(direcion.x,360);
                _transform.Rotate(0, PlayerRotate, 0);
            }

            if (direcion.y != 0)
            {
                float RotateCamera = direcion.y + _camera.transform.rotation.y;

                if (Mathf.Abs(RotateCamera) < _maxAngleCamera)
                    _camera.transform.Rotate(-direcion.y, 0, 0);
            }
        }

        public void SitDownActive(bool isSitdown)
        {
            if (isSitdown)
            {
                if (_isSitDown)
                    return;

                _isSitDown = true;
                OnSitDown?.Invoke(isSitdown);
            }
            else
            {
                 if (_isSitDown == false)
                    return;


                _isSitDown = false;
                OnSitDown?.Invoke(isSitdown);
            }
        }
    }
}
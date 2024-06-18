using Game.Inputs;
using Game.Model;
using UnityEngine;

namespace Game.CompositRoot
{
    public class PlayerCompositRoot : CompositRoot
    {
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private Camera _cameraPlayer;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Animator _animator;

        private PlayerInputRouter _playerInpurRouter;
        private Player _player;
        private PlayerHealth _health;
        private PlayerMovement _movement;

        public int MaxHealth => _health.MaxHealth;
        public float Healse => _health.CurentHealth;

        public override void Compose()
        {
            _player = new Player(_cameraPlayer,_controller,_transformPlayer,Conffig.MaxAngleCamera);
            _health = new PlayerHealth(Conffig.StartHealthPlayer);
            _movement = new PlayerMovement(_player, new InertMovement(Conffig.AccaleratePerSecond, Conffig.AccalerateMaxSpeed, Conffig.AccalerateSpeed, new Zoom(_cameraPlayer, Conffig.ZoomDuringAcceleration, Conffig.TimeZoom, Conffig.SpeedZoom)), 
               Conffig.Gravity,Conffig.ForceJumpe,Conffig.RaycastLengh,Conffig.Sensitivity,Conffig.SpeedMovePlayer);
            _playerInpurRouter = new PlayerInputRouter(_movement);
        }

        private void OnEnable()
        {
            _playerInpurRouter.OnEnable();
        }

        private void OnDisable()
        {
            _playerInpurRouter.OnDisable();
        }

        private void Update()
        {
            _playerInpurRouter.Update(Time.deltaTime);
            _health.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _playerInpurRouter.FixedUpdete();
        }
    }
}
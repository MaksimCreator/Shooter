using Game.Model;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Game.Inputs
{
    public class PlayerInputRouter
    {
        private readonly PlayerInput _input;
        private readonly PlayerMovement _movement;

        public PlayerInputRouter(PlayerMovement movement)
        {
            _movement = movement;
            _input = new PlayerInput();
        }

        public void OnEnable()
        {
            _input.Enable();
            _input.Movements.SitDown.performed += OnSitDown;
        }

        public void OnDisable()
        {
            _input.Disable();
            _input.Movements.SitDown.performed -= OnSitDown;
        }

        public void Update(float delta)
        {
            if (delta < 0)
                throw new InvalidOperationException(nameof(delta));

            if (_input.Movements.Move.phase == InputActionPhase.Performed)
                _movement.Move(_input.Movements.Move.ReadValue<Vector2>());

            if (_input.Movements.Rotate.phase == InputActionPhase.Performed)
                _movement.Rotate(_input.Movements.Rotate.ReadValue<Vector2>());

            if (_input.Movements.Jumpe.phase == InputActionPhase.Performed)
                _movement.Jumpe();

            if (_input.Movements.Accalerate.phase == InputActionPhase.Performed)
                _movement._inert.Accalerate(delta);
            else
                _movement._inert.Slodown(delta);

            _movement.Update(delta);
        }

        public void FixedUpdete() => _movement.FixedUpdete();

        private void OnSitDown(InputAction.CallbackContext context)
        {
            _movement.SitDown();
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private InputActions _inputActions;

        public event Action<Vector2> OnMoved;
        public event Action OnJumped;
        public event Action OnAttack;

        private void Awake()
        {
            _inputActions = new InputActions();
        }

        private void OnMove(InputValue inputValue)
        {
            OnMoved?.Invoke(inputValue.Get<Vector2>());
        }

        private void OnJump ()
        {
            OnJumped?.Invoke();
        }

        private void OnFire()
        {
            Debug.Log("fire");
            OnAttack?.Invoke();
        }
    }
}
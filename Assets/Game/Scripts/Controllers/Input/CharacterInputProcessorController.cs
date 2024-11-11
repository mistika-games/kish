using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Core;
using Game.Scripts.Models;
using UnityEngine;

namespace Game.Scripts.Controllers.Input
{
    public class CharacterInputProcessorController : BaseCoreController
    {
        private readonly ICharacterModel _characterModel;
        private readonly InputManager _inputManager;
        private Vector2 _moveDirection;

        public CharacterInputProcessorController (ICharacterModel characterModel, InputManager inputManager)
        {
            _characterModel = characterModel;
            _inputManager = inputManager;
        }

        protected override void OnInit()
        {
            _inputManager.OnJumped += _characterModel.Jump;
            _inputManager.OnAttack += _characterModel.Attack;
            _inputManager.OnMoved += UpdateMovement;
        }

        private void UpdateMovement(Vector2 direction)
        {
            _moveDirection = direction;
            _characterModel.SetDirection(direction);
        }

        protected override void OnDispose()
        {
            _inputManager.OnJumped -= _characterModel.Jump;
            _inputManager.OnMoved -= _characterModel.Move;
            _inputManager.OnAttack -= _characterModel.Attack;
        }
        
        public void Update()
        {
            _characterModel.Move(_moveDirection);
        }
    }
}
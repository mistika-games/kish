﻿using Game.Scripts.Containers;
using Game.Scripts.Controllers.Input;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Updaters;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Controllers
{
    [RequireComponent(typeof(CharacterContainer))]
    public class PlayerController : MonoBehaviour 
    {
        private ICharacterModel _playerModel;
        private CharacterAnimationUpdater _characterAnimationUpdater;
        private ICharacterPhysicsController _characterPhysicsController;
        private CharacterInputProcessorController _inputProcessorController;
        private InputManager _inputManager;

        [SerializeField]
        private CharacterContainer _container;

        [SerializeField] private string id;

        [Inject]
        public void Construct(InputManager inputManager, ICharacterModel playerModel, ICharacterPhysicsController characterPhysicsController)
        {
            _inputManager = inputManager;

            _playerModel = playerModel;
            _playerModel.SetId(id);

            _characterPhysicsController = characterPhysicsController;
            _characterPhysicsController.SetUp(playerModel, _container.Rigidbody2D, _container.GroundedCollider, _container.InteractionEffector);
            _characterAnimationUpdater = new CharacterAnimationUpdater(_container.Animator, _playerModel);
            _inputProcessorController = new CharacterInputProcessorController(_playerModel, _inputManager);
            
            _characterPhysicsController.Init();
            _inputProcessorController.Init();
        }

        public void Update()
        {
            _characterAnimationUpdater.Update();
            _inputProcessorController.Update();
        }

        public void FixedUpdate()
        {
            _characterPhysicsController.FixedUpdate();
        }

        public void OnDestroy()
        {
            _inputProcessorController?.Dispose();
            _characterPhysicsController?.Dispose();
        }
    }
}
using Game.Scripts.Containers;
using Game.Scripts.Controller;
using Game.Scripts.Controllers;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using Game.Scripts.Updaters;
using UnityEngine;
using VContainer;

namespace Game.Scripts
{
    [RequireComponent(typeof(CharacterContainer))]
    public class PlayerController : MonoBehaviour 
    {
        private ICharacterModel _playerModel;
        private CharacterAnimationUpdater _characterAnimationUpdater;
        private ICharacterPhysicsController _physicsController;
        private CharacterInputProcessorController _inputProcessorController;
        private InputManager _inputManager;
        private CharacterSettings _characterSettings;
        
        [SerializeField]
        private CharacterContainer _container;

        [SerializeField] private string id;

        [Inject]
        public void Construct(InputManager inputManager, CharacterSettings characterSettings, ICharacterModel playerModel, ICharacterPhysicsController physicsController)
        {
            _inputManager = inputManager;
            _characterSettings = characterSettings;
    
            _playerModel = playerModel;
            _playerModel.SetId(id);
            Debug.Log($"We are in player_id = {playerModel.Id}");
            
            _physicsController = physicsController;
            _physicsController.SetUp(_playerModel, _container.Rigidbody2D, _container.GroundedCollider);
            
            _characterAnimationUpdater = new CharacterAnimationUpdater(_container.Animator, _playerModel);
            _inputProcessorController = new CharacterInputProcessorController(_playerModel, _inputManager);
            
            _physicsController.Init();
            _inputProcessorController.Init();
        }

        public void Update()
        {
            _characterAnimationUpdater.Update();
            _inputProcessorController.Update();
        }

        public void FixedUpdate()
        {
            _physicsController.Update();
        }

        public void OnDestroy()
        {
            _inputProcessorController?.Dispose();
            _physicsController?.Dispose();
        }
    }
}
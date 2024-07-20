using Game.Scripts.Containers;
using Game.Scripts.Controllers.Input;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.ScriptableObjects;
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
        private CharacterHorizontalFlipController _characterHorizontalFlipController;
        private InputManager _inputManager;

        [SerializeField]
        private CharacterContainer _container;
        
        [SerializeField] 
        private CharacterModelDescription _characterModelDescription;

        [Inject]
        public void Construct(InputManager inputManager, ICharacterModel playerModel, ICharacterPhysicsController characterPhysicsController)
        {
            _inputManager = inputManager;

            _playerModel = playerModel;
            _playerModel.SetDescription(_characterModelDescription);

            _characterPhysicsController = characterPhysicsController;
            _characterPhysicsController.SetUp(playerModel, _container.Rigidbody2D, _container.GroundedCollider, _container.PhysicsAttackBehaviour);
            _characterHorizontalFlipController = new CharacterHorizontalFlipController(_playerModel);
            _characterAnimationUpdater = new CharacterAnimationUpdater(_container.Animator, _playerModel, _characterHorizontalFlipController);
            _inputProcessorController = new CharacterInputProcessorController(_playerModel, _inputManager);
            
            _characterHorizontalFlipController.FlipRight += _container.HorizontalFlipBehaviour.FlipRight;
            _characterHorizontalFlipController.FlipLeft += _container.HorizontalFlipBehaviour.FlipLeft;
            
            _characterAnimationUpdater.Init();
            _characterPhysicsController.Init();
            _inputProcessorController.Init();
        }

        public void Update()
        {
            _characterHorizontalFlipController.Update();
            _characterAnimationUpdater.Update();
            _inputProcessorController.Update();
        }

        public void FixedUpdate()
        {
            _characterPhysicsController.FixedUpdate();
        }

        public void OnDestroy()
        {
            _characterHorizontalFlipController.FlipRight -= _container.HorizontalFlipBehaviour.FlipRight;
            _characterHorizontalFlipController.FlipLeft -= _container.HorizontalFlipBehaviour.FlipLeft;
            
            _inputProcessorController?.Dispose();
            _characterPhysicsController?.Dispose();
            _characterAnimationUpdater?.Dispose();
        }
    }
}
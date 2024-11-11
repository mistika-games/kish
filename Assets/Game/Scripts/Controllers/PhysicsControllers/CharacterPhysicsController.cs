using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Core;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Controllers.PhysicsControllers
{
    [UsedImplicitly]
    public class CharacterPhysicsController : BaseCoreController, ICharacterPhysicsController
    {
        private readonly ICharacterMovementPhysicsController _movementPhysicsController;
        private readonly ICharacterAttackPhysicsController _attackPhysicsController;
        private ICharacterModel _characterModel;
        
        public CharacterPhysicsController(ICharacterMovementPhysicsController movementPhysicsController, ICharacterAttackPhysicsController attackPhysicsController)
        {
            _movementPhysicsController = movementPhysicsController;
            _attackPhysicsController = attackPhysicsController;
        }
        
        public void SetUp(ICharacterModel characterModel, Rigidbody2D rigidbody2D, Collider2D groundedCollider, IAttackBehaviour physicsAttackBehaviour)
        {
            _characterModel = characterModel;
            _movementPhysicsController.SetUp(_characterModel, rigidbody2D,groundedCollider);
            _attackPhysicsController.SetUp(_characterModel, physicsAttackBehaviour);
        }

        public void FixedUpdate()
        {
            _movementPhysicsController.FixedUpdate();
        }
        
        protected override void OnInit()
        {
            _movementPhysicsController.Init();
            _attackPhysicsController.Init();
        }
        
        protected override void OnDispose()
        {
            _movementPhysicsController.Dispose();
            _attackPhysicsController.Dispose();
        }
    }
}
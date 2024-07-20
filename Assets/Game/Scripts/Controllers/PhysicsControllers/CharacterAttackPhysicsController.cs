using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Controllers.PhysicsControllers
{
    [UsedImplicitly]
    public class CharacterAttackPhysicsController : ICharacterAttackPhysicsController
    {
        private ICharacterModel _characterModel;
        private IAttackBehaviour _attackBehaviour;
        
        public void Init()
        {
            _characterModel.OnAttack += PerformAttack;
        }
        
        public void SetUp(ICharacterModel characterModel, IAttackBehaviour attackBehaviour)
        {
            _characterModel = characterModel;
            _attackBehaviour = attackBehaviour;
        }

        public void PerformAttack()
        {
         _attackBehaviour.PerformAttack();
        }
        
        public void Dispose()
        {
            _characterModel.OnAttack -= PerformAttack;
        }
    }
}
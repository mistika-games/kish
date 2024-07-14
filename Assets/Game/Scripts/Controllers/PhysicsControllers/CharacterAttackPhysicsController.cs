using Game.Scripts.Controllers.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Controllers.PhysicsControllers
{
    [UsedImplicitly]
    public class CharacterAttackPhysicsController : ICharacterAttackPhysicsController
    {
        private ICharacterModel _characterModel;
        private Effector2D _effector2D;
        
        public void Init()
        {
            _characterModel.OnAttack += PerformAttack;
        }

        public void Dispose()
        {
            _characterModel.OnAttack -= PerformAttack;
        }

        public void SetUp(ICharacterModel characterModel, Effector2D effector2D)
        {
            _characterModel = characterModel;
            _effector2D = effector2D;
        }

        public void PerformAttack()
        {
            if (_characterModel.IsAttacking)
            {
                
            }
        }
    }
}
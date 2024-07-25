using Game.Scripts.Behaviours;
using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Structs;
using JetBrains.Annotations;

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
            var interactionSourceData = new SourceInteractionData()
            {
                SourcePosition = _characterModel.Position,
                SourceVelocity = _characterModel.Velocity
            };
            
            _attackBehaviour.PerformAttack(interactionSourceData);
        }
        
        public void Dispose()
        {
            _characterModel.OnAttack -= PerformAttack;
        }
    }
}
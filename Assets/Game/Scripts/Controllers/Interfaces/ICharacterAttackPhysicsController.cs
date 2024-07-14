using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface ICharacterAttackPhysicsController : ICoreController
    {
        void SetUp(ICharacterModel characterModel,Effector2D effector2D);
        void PerformAttack();
    }
}
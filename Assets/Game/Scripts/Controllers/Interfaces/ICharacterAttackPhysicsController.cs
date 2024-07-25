namespace Game.Scripts.Controllers.Interfaces
{
    public interface ICharacterAttackPhysicsController : ICoreController
    {
        void SetUp(ICharacterModel characterModel, IAttackBehaviour _attackBehaviour);
        void PerformAttack();
    }
}
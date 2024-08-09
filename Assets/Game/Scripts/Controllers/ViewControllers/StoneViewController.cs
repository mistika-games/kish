using Game.Scripts.Containers;
using Game.Scripts.Core;
using Game.Scripts.Models;

namespace Game.Scripts.Controllers.ViewControllers
{
    public class StoneViewController : BaseCoreController
    {
        private readonly IStoneModel _stoneModel;
        private readonly StoneBehaviourContainer _stoneBehaviourContainer;

        public StoneViewController(IStoneModel stoneModel, StoneBehaviourContainer stoneBehaviourContainer)
        {
            _stoneModel = stoneModel;
            _stoneBehaviourContainer = stoneBehaviourContainer;
        }

        protected override void OnInit()
        {
            AttachView();
        }

        public void RespawnView()
        {
            _stoneBehaviourContainer.SpawnEvent?.Invoke();
        }

        private void AttachView()
        {
            _stoneModel.Damaged += OnStoneDamaged;
            _stoneModel.Crushed += OnStoneCrushed;
        }

        private void DetachView()
        {
            _stoneModel.Damaged -= OnStoneDamaged;
            _stoneModel.Crushed -= OnStoneCrushed;
        }

        private void OnStoneDamaged(int previousHp, int currentHp)
        {
            _stoneBehaviourContainer.HitEvent?.Invoke();
        }

        private void OnStoneCrushed()
        {
            _stoneBehaviourContainer.CrushEvent?.Invoke();
        }

        protected override void OnDispose()
        {
            DetachView();
        }
    }
}
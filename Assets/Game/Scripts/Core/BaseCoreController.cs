using Game.Scripts.Controllers.Interfaces;

namespace Game.Scripts.Core
{
    public abstract class BaseCoreController : ICoreController
    {
        private bool _isInited;

        public void Init()
        {
            if (_isInited) 
                return;
            
            _isInited = true;
            OnInit();
        }

        protected abstract void OnInit();
        protected abstract void OnDispose();

        public void Dispose()
        {
            if (!_isInited) 
                return;
            
            _isInited = false;
            OnDispose();
        }
    }
}
using System;
using Game.Scripts.Controllers.Interfaces;

namespace Game.Scripts.Controllers
{
    public class CharacterHorizontalFlipController
    {
        public event Action FlipRight;
        public event Action FlipLeft;
        
        public bool IsFacingRight
        {
            get => _isFacingRight;
            private set
            {
                if (_isFacingRight != value)
                {
                    if (_isFacingRight)
                        FlipLeft?.Invoke();
                    else
                        FlipRight?.Invoke();
                }
                _isFacingRight = value;
            }
        }
        
        private readonly ICharacterModel _characterModel;
        private bool _isFacingRight;
        
        public CharacterHorizontalFlipController(ICharacterModel characterModel)
        {
            _characterModel = characterModel;
            _isFacingRight = _characterModel.Direction.x >= 0;
        }

        public void Update()
        {
            if (_characterModel.Direction.x == 0)
                return;

            IsFacingRight = _characterModel.Direction.x > 0;
        }
    }
}
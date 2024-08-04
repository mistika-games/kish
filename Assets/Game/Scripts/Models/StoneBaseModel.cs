using System;
using Game.Scripts.ScriptableObjects;

namespace Game.Scripts.Models
{
    public abstract class StoneBaseModel 
    {
        public event Action Crush;
        public event Action<int, int> HpChange;

        public int Durability
        {
            get => _currentDurability;
            private set
            {
                var oldValue = _currentDurability;
                _currentDurability = value;
                HpChange?.Invoke(oldValue, _currentDurability);

                if (_currentDurability <= 0)
                {
                    Crush?.Invoke();
                }
            }
        }
        public float Mass { get; private set; }
        
        private int _currentDurability;

        protected StoneBaseModel(StoneModelDescription stoneModelDescription)
        {
            _currentDurability = stoneModelDescription.MaxHp;
            Mass = stoneModelDescription.Mass;
        }

        public void TakeDamage(int damageTaken)
        {
            Durability -= damageTaken;
        }
    }
}
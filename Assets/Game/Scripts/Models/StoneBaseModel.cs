using System;
using Game.Scripts.ScriptableObjects;

namespace Game.Scripts.Models
{
    public abstract class StoneBaseModel : IStoneModel
    {
        public event Action Crushed;
        public event Action<int, int> Damaged;

        public int Durability
        {
            get => _currentDurability;
            private set
            {
                var oldValue = _currentDurability;
                _currentDurability = value;
                Damaged?.Invoke(oldValue, _currentDurability);

                if (_currentDurability <= 0)
                {
                    Crushed?.Invoke();
                }
            }
        }
        public float Mass { get; private set; }
        
        private int _currentDurability;

        protected StoneBaseModel(StoneModelDescription stoneModelDescription)
        {
            Mass = stoneModelDescription.Mass;
            _currentDurability = stoneModelDescription.MaxHp;
        }

        public void TakeDamage(int damageTaken = 1)
        {
            Durability -= damageTaken;
        }

        public void Rebuild(StoneModelDescription stoneModelDescription)
        {
            Mass = stoneModelDescription.Mass;
            _currentDurability = stoneModelDescription.MaxHp;
        }
    }
}
using System;
using Game.Scripts.ScriptableObjects;

namespace Game.Scripts.Models
{
    public interface IStoneModel
    {
        public event Action Crushed;
        public event Action<int, int> Damaged;
        public int Durability { get; }
        public void TakeDamage(int damageTaken);
        void Rebuild(StoneModelDescription stoneModelDescription);
    }
}
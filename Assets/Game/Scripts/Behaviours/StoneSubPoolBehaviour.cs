using System.Collections.Generic;
using Game.Scripts.ScriptableObjects;
using Lean.Pool;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Behaviours
{
    public class StoneSubPoolBehaviour : MonoBehaviour
    {
        [SerializeField] private int _maxStoneAmount;
        [SerializeField] private float _seconds;
        [SerializeField] private float _spawnTimer = 1;
        [SerializeField] private Transform SpawnPosition;
        [SerializeField] private Transform Direction;
        
        private StoneBehaviourController _stoneBehaviourController;
        private Queue<StoneBehaviourController> _activeStones = new();

        [Inject]
        void Construct(Catalog catalog)
        {
            _stoneBehaviourController = catalog.StoneBehaviourController;
        }

        private void Update()
        {
            _seconds += Time.deltaTime;

            if (_seconds < _spawnTimer) 
                return;
            
            _seconds = 0;
            SpawnNewStone();

            if (_activeStones.Count < _maxStoneAmount) 
                return;
            
            var oldestStone = _activeStones.Dequeue();
            LeanPool.Despawn(oldestStone);

        }

        private void SpawnNewStone()
        {
            var newStone = LeanPool.Spawn(_stoneBehaviourController, SpawnPosition);
            _activeStones.Enqueue(newStone);
        }
    }
}
using Lean.Pool;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Spawn
{
    public class StoneSpawner : MonoBehaviour
    {
        public GameObject StonePrefab;

        private void Start()
        {
            LeanPool.Spawn(StonePrefab, transform.position, quaternion.identity);
        }
    }
}
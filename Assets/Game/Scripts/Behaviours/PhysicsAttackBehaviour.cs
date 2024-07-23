using System.Collections;
using Game.Scripts.Containers;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PhysicsAttackBehaviour : MonoBehaviour , IAttackBehaviour
    {
        private Coroutine _attackCoroutine;
        public Effector2D InteractionEffector;
        public float duration = 0.1f;
        
        public void PerformAttack()
        {
            _attackCoroutine ??= StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            InteractionEffector.enabled = true;
            yield return new WaitForSeconds(duration);
            InteractionEffector.enabled = false;
            _attackCoroutine = null;
        }
    }
}
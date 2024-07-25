using Game.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class SimpleStoneBehaviour : MonoBehaviour, IHitInteractableBehaviour
    {
        [SerializeField] private float interactionStrength;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public void InteractWithHit(IInteractionParameters interactionParameters)
        {
            var direction = transform.position - interactionParameters.SourceData.SourcePosition;
            _rigidbody2D.AddForce(direction * interactionStrength, ForceMode2D.Impulse);
        }

        private void Reset()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
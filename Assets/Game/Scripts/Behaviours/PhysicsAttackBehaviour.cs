using System.Collections.Generic;
using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Structs;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PhysicsAttackBehaviour : MonoBehaviour , IAttackBehaviour
    {
        public Effector2D InteractionEffector;
        public float duration = 0.1f;

        private List<IHitInteractable> _interactableObjects;
        
        public void PerformAttack(IInteractionSourceData sourceData)
        {
            var interactionParameters = new PhysicsInteractionParameters()
            {
                SourceData = sourceData,
                InteractionPoint = transform.position
            };
            
            foreach (var interactable in _interactableObjects)
            {
                interactable.InteractWithHit(interactionParameters);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<IHitInteractable>() is { } interactable )
            {
                _interactableObjects.Add(interactable);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.GetComponent<IHitInteractable>() is { } interactable && _interactableObjects.Contains(interactable))
            {
                _interactableObjects.Remove(interactable);
            }
        }
    }
}
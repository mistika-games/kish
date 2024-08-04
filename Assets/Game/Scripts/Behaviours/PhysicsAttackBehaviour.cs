using System.Collections.Generic;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Structs;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PhysicsAttackBehaviour : MonoBehaviour , IAttackBehaviour
    {
        private readonly List<IInteractableHit> _interactableObjects = new();
        
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<IInteractableHit>() is { } interactable )
            {
                _interactableObjects.Add(interactable);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<IInteractableHit>() is { } interactable && _interactableObjects.Contains(interactable))
            {
                _interactableObjects.Remove(interactable);
            }
        }

        private void OnDestroy()
        {
            _interactableObjects.Clear();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Structs;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PhysicsAttackBehaviour : MonoBehaviour , IAttackBehaviour
    {
        private readonly HashSet<IInteractableHit> _interactableObjects = new();
        private readonly HashSet<IInteractableHit> _markForRemove = new();
        
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
                _markForRemove.Add(interactable);
            }
        }

        private void Update()
        {
            ClearRemovedObjects();
        }

        private void ClearRemovedObjects()
        {
            if (_markForRemove.Any())
            {
                foreach (var hitInteractableItem in _markForRemove)
                {
                    _interactableObjects.Remove(hitInteractableItem);
                }
            }
            _markForRemove.Clear();
        }
        
        private void OnDestroy()
        {
            _interactableObjects.Clear();
        }
    }
}
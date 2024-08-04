using System;
using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using UnityEngine;


namespace Game.Scripts.Behaviours
{
    public class StoneBehaviourController : MonoBehaviour, IInteractableCollision, IInteractableHit
    {
        [SerializeField] private StoneModelDescription _stoneModelDescription;
        [SerializeField] private StoneBehaviourContainer _stoneBehaviourContainer;

        private SimpleStoneModel _stoneModel;

        public void Awake()
        {
            if (_stoneModel is null)
                Setup();
        }

        public void Setup()
        {
            _stoneModel = new SimpleStoneModel(_stoneModelDescription);
            _stoneBehaviourContainer.Rigidbody2D.mass = _stoneModelDescription.Mass;
        }

        public void InteractWithCollision(IInteractionParameters interactionParameters)
        {
            throw new NotImplementedException();
        }

        public void InteractWithHit(IInteractionParameters interactionParameters)
        {
            var direction = transform.position - interactionParameters.SourceData.SourcePosition;
            _stoneBehaviourContainer.Rigidbody2D.AddForce(direction * interactionParameters.SourceData.SourceStrength * _stoneModelDescription.InteractionForceMultiplier, ForceMode2D.Impulse);
        }
    }
}
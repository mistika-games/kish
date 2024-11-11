using System;
using Game.Scripts.Containers;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Controllers.ViewControllers;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using Lean.Pool;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class StoneBehaviourController : MonoBehaviour, IInteractableCollision, IInteractableHit, IPoolable
    {
        [SerializeField] private StoneModelDescription _stoneModelDescription;
        [SerializeField] private StoneBehaviourContainer _stoneBehaviourContainer;

        private bool _isFirstTimeCreated = true;
        private IStoneModel _stoneModel;
        private StoneViewController _stoneViewController;

        public void Start()
        {
            if (_isFirstTimeCreated)
            {
                OnSpawn();
            }
        }

        private void Init()
        {
            if (_isFirstTimeCreated)
            {
                _stoneModel = new SimpleStoneModel(_stoneModelDescription);
                _stoneViewController = new StoneViewController(_stoneModel, _stoneBehaviourContainer);
                _stoneViewController.Init();

                _stoneModel.Crushed += Despawn;

                _isFirstTimeCreated = false;
            }
            
            _stoneViewController.RespawnView();
        }

        public void OnSpawn()
        {
            Init();
            ResetPhysics();
        }

        private void ResetPhysics()
        {
            _stoneBehaviourContainer.Rigidbody2D.mass = _stoneModelDescription.Mass;
            _stoneBehaviourContainer.Rigidbody2D.velocity = Vector2.zero;
            _stoneBehaviourContainer.Rigidbody2D.angularVelocity = 0;
        }

        public void InteractWithCollision(IInteractionParameters interactionParameters)
        {
            throw new NotImplementedException();
        }

        public void InteractWithHit(IInteractionParameters interactionParameters)
        {
            InteractPhysics(interactionParameters);
            _stoneModel.TakeDamage(interactionParameters.SourceData.SourceDamage);
        }

        private void InteractPhysics(IInteractionParameters interactionParameters)
        {
            var direction = transform.position - interactionParameters.SourceData.SourcePosition;
            _stoneBehaviourContainer.Rigidbody2D.AddForce(direction * interactionParameters.SourceData.SourceStrength * _stoneModelDescription.InteractionForceMultiplier, ForceMode2D.Impulse);
        }

        private void Despawn()
        {
            LeanPool.Despawn(this, 1);
        }

        public void OnDespawn()
        {
            _stoneModel.Rebuild(_stoneModelDescription);
        }

        public void OnDestroy()
        {
            _stoneModel.Crushed -= Despawn;
            _stoneViewController.Dispose();
        }
    }
}
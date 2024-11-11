using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.Core;
using Game.Scripts.Models;
using Game.Scripts.ScriptableObjects;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Controllers.PhysicsControllers
{
    [UsedImplicitly]
    public class CharacterMovementPhysicsController : BaseCoreController, ICharacterMovementPhysicsController
    {
        private readonly ContactFilter2D _contactFilter2D;
        private readonly Collider2D[] _overlapResults;
        private readonly float _horizontalVelocityDamping;
        
        private ICharacterModel _characterModel;
        private  Rigidbody2D _rigidbody2D;
        private  Collider2D _groundedCollider;

        public CharacterMovementPhysicsController(GameConfiguration gameConfiguration)
        {
            _overlapResults = new Collider2D[1];
            _horizontalVelocityDamping = gameConfiguration.HorizontalVelocityDamping;
            _contactFilter2D = new ContactFilter2D() { useLayerMask = true, layerMask = gameConfiguration.GroundedLayerMask };
        }

        public void SetUp(ICharacterModel characterModel, Rigidbody2D rigidbody2D, Collider2D groundedCollider)
        {
            _characterModel = characterModel;
            _rigidbody2D = rigidbody2D;
            _groundedCollider = groundedCollider;
        }
        
        protected override void OnInit()
        {
            Attach();
        }

        public void FixedUpdate()
        {
            _characterModel.SetVelocity(_rigidbody2D.velocity);
            _characterModel.SetPosition(_rigidbody2D.transform.position);
            _characterModel.SetGrounded(CalculateGrounded());
        }

        private bool CalculateGrounded()
        {
            return Physics2D.OverlapCollider(_groundedCollider, _contactFilter2D, _overlapResults) > 0;
        }

        private void TryPerformJump()
        {
            if (_characterModel.IsGrounded)
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _characterModel.JumpForce);
        }

        private void Attach()
        {
            _characterModel.OnJump += TryPerformJump;
            _characterModel.OnMove += PerformMovement;
        }

        private void PerformMovement(Vector2 inputValue)
        {
            var xVelocity = Mathf.Lerp(_rigidbody2D.velocity.x, _characterModel.MaxSpeed * inputValue.x, Time.deltaTime * _horizontalVelocityDamping);
            _rigidbody2D.velocity = new Vector2(xVelocity, _rigidbody2D.velocity.y);
        }

        private void Detach()
        {
            _characterModel.OnJump -= TryPerformJump;
            _characterModel.OnMove -= PerformMovement;
        }

        protected override void OnDispose()
        {
            Detach();
        }
    }
}
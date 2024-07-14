using System;
using Game.Scripts.Controllers.Interfaces;
using Game.Scripts.ScriptableObjects;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Scripts.Models
{
    [UsedImplicitly]
    public class CharacterModel : ICharacterModel
    {
        private CharacterModelDescription _characterModelDescription;
        public event Action OnJump;
        public event Action<Vector2> OnMove;
        public event Action OnAttack;
        
        public Vector2 Direction { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }

        public float JumpForce => _characterModelDescription.JumpForce;
        public float MaxSpeed => _characterModelDescription.MaxMovementSpeed;
        public float AttackCooldown => _characterModelDescription.AttackCooldown;

        private float _lastAttackTs;
        
        public void SetDescription(CharacterModelDescription characterModelDescription)
        {
            _characterModelDescription = characterModelDescription;
        }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void SetGrounded(bool isGrounded)
        {
            IsGrounded = isGrounded;
        }

        public void Jump()
        {
            OnJump?.Invoke();
        }

        public void Move(Vector2 movementVector)
        {
            OnMove?.Invoke(movementVector);
        }

        public void Attack()
        {
            if (!(Time.time > _lastAttackTs + AttackCooldown)) 
                return;
            
            OnAttack?.Invoke();
            _lastAttackTs = Time.time;
        }
    }
}
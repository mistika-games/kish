using System;
using Game.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace Game.Scripts.Models
{
    public class CharacterModel : ICharacterModel
    {
        public event Action OnJump;
        public event Action<Vector2> OnMove;
        public event Action OnAttack; 
        
        public string Id { get; private set; }
        public Vector2 Position { get;private set; }
        public Vector2 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsAttacking { get; private set; }

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
            OnAttack?.Invoke();
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}
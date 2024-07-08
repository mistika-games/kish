using System;
using UnityEngine;

namespace Game.Scripts.Models
{
    public interface ICharacterModel
    {
        event Action OnJump;
        event Action<Vector2> OnMove;
        event Action OnAttack;

        public string Id { get; }
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        bool IsGrounded { get; }
        bool IsAttacking { get; }
        void SetVelocity(Vector2 velocity);
        void SetPosition(Vector2 position);
        void SetGrounded(bool isGrounded);
        void Jump();
        void Move(Vector2 movementVector);
        void Attack();
        void SetId(string id);
    }
}
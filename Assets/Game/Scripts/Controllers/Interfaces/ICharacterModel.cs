using System;
using Game.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface ICharacterModel
    {
        event Action OnJump;
        event Action OnAttack;
        event Action<Vector2> OnMove;

        public float JumpForce { get; }
        public float MaxSpeed { get; }
        public float AttackCooldown { get; }
        public string Id { get; }
        public Vector2 Direction { get; }
        
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        bool IsGrounded { get; }
        
        void SetDescription(CharacterModelDescription characterModelDescription);

        void SetDirection(Vector2 direction);
        void SetVelocity(Vector2 velocity);
        void SetPosition(Vector2 position);
        void SetGrounded(bool isGrounded);
        
        void Attack();
        void Jump();
        void Move(Vector2 movementVector);
    }
}
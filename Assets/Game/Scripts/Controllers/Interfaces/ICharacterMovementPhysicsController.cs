using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface ICharacterMovementPhysicsController : ICoreController
    {
        void FixedUpdate();
        void SetUp(ICharacterModel characterModel, Rigidbody2D rigidbody2D, Collider2D groundedCollider);
    }
}
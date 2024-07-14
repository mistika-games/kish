﻿using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface ICharacterPhysicsController : ICoreController
    {
        void SetUp(ICharacterModel characterModel, Rigidbody2D rigidbody2D, Collider2D groundedCollider, Effector2D interactionEffector);
        void FixedUpdate();
    }
}
using Game.Scripts.Behaviours;
using UnityEngine;

namespace Game.Scripts.Containers
{
    public class CharacterContainer : MonoBehaviour
    {
        public PhysicsAttackBehaviour PhysicsAttackBehaviour;
        public HorizontalFlipBehaviour HorizontalFlipBehaviour;
        public Animator Animator;
        public Rigidbody2D Rigidbody2D;
        public Collider2D GroundedCollider;
    }
}
using UnityEngine;

namespace Game.Scripts.Containers
{
    public class CharacterContainer : MonoBehaviour
    {
        public Effector2D InteractionEffector;
        public Animator Animator;
        public Rigidbody2D Rigidbody2D;
        public Collider2D GroundedCollider;
    }
}
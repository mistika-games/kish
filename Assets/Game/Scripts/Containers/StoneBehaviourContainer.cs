using UnityEngine;
using UnityEngine.Events;

namespace Game.Scripts.Containers
{
    public class StoneBehaviourContainer : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        
        public UnityEvent SpawnEvent;
        public UnityEvent HitEvent;
        public UnityEvent CrushEvent;
    }
}
using UnityEngine;

namespace Game.Scripts.Containers
{
    public class StoneBehaviourContainer : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        
        private void Reset()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class HorizontalFlipBehaviour : MonoBehaviour
    {
        public void FlipRight()
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        public void FlipLeft()
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
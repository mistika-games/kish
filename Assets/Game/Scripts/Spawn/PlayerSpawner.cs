using Game.Scripts.Camera;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Spawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Inject]
        public void Construct(PlayerController playerController)
        {
            playerController.transform.position = transform.position;
        }
    }
}
using Game.Scripts.Controllers;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Spawn
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Inject]
        public void Construct(PlayerBehaviourController playerBehaviourController)
        {
            playerBehaviourController.transform.position = transform.position;
        }
    }
}
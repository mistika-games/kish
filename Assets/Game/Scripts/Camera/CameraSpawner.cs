using Game.Scripts.Controllers;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Camera
{
    public class CameraSpawner : MonoBehaviour
    {
        [Inject]
        void Construct(PlayerBehaviourController playerBehaviourController, CameraInjector cameraInjector)
        {
            cameraInjector.CinemachineVirtualCamera.Follow = playerBehaviourController.transform;
            cameraInjector.transform.position = transform.position;
        }
    }
}
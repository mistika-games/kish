using Game.Scripts.Controllers;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Camera
{
    public class CameraSpawner : MonoBehaviour
    {
        [Inject]
        void Construct(PlayerController playerController, CameraInjector cameraInjector)
        {
            cameraInjector.CinemachineVirtualCamera.Follow = playerController.transform;
            cameraInjector.transform.position = transform.position;
        }
    }
}
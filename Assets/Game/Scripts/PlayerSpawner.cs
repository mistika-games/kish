using Game.Scripts;
using UnityEngine;
using VContainer;

public class PlayerSpawner : MonoBehaviour
{
    [Inject]
    public void Construct(PlayerController playerController)
    {
        playerController.transform.position = transform.position;
    }
}

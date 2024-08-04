using Game.Scripts.Camera;
using Game.Scripts.Controllers;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName="Catalog",menuName= "kish/Catalog")]
    public class Catalog : ScriptableObject
    {
        public InputManager InputManager;
        public PlayerBehaviourController _playerBehaviour;
        public CameraInjector FollowCamera;

        public GameConfiguration GameConfiguration;
    }
}
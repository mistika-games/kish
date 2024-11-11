using Game.Scripts.Behaviours;
using Game.Scripts.Camera;
using Game.Scripts.Controllers;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName="Catalog",menuName= "kish/Catalog")]
    public class Catalog : ScriptableObject
    {
        public InputManager InputManager;
        public PlayerBehaviourController PlayerBehaviour;
        public CameraInjector FollowCamera;
        public StoneBehaviourController StoneBehaviourController;

        public GameConfiguration GameConfiguration;
    }
}
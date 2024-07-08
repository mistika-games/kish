using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName="Catalog",menuName= "kish/Catalog")]
    public class Catalog : ScriptableObject
    {
        public InputManager InputManager;
        public PlayerController Player;

        public GameConfiguration GameConfiguration;
    }
}
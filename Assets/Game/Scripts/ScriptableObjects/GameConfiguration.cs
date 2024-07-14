using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Kish/Settings")]
    public class GameConfiguration : ScriptableObject
    {
        public float Gravity2D = -15f;
        public float HorizontalVelocityDamping = 10;
        
        [Title("Levels")] [SerializeField] 
        public LevelNames LevelNames;

        [Title("Character Settings")] [SerializeField]
        public CharacterSettings CharacterSettings;
    }

    [Serializable]
    public class CharacterSettings
    {
        public float HorizontalVelocityDamping = 5;
        public CharacterModelDescription _characterModelDescription;
    }

    [Serializable]
    public class LevelNames
    {
        public string Level1 = "level_1";
    }
}

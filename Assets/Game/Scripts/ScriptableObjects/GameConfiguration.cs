using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Kish/Settings")]
    public class GameConfiguration : ScriptableObject
    {
        [Title("Character Settings")] [SerializeField]
        public CharacterSettings CharacterSettings;

        private void OnValidate()
        {
            Physics2D.gravity = new Vector2(0,CharacterSettings.Gravity2D);
        }
    }

    [Serializable]
    public class CharacterSettings
    {
        public float HorizontalVelocityDamping = 5;
        public float MaxSpeed = 7;
        public float JumpForce = 15f;
        public float Gravity2D = -10f;
    }
}

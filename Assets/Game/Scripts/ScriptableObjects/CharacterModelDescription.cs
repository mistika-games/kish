using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterDescription", menuName = "kish/CharacterDescription")]
    public class CharacterModelDescription : ScriptableObject
    {
        public string Id;
        public float JumpForce;
        public float MaxMovementSpeed;
        public float AttackCooldown;
    }
}
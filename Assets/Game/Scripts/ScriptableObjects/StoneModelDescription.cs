using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StoneDescription", menuName = "kish/StoneDescription")]
    public class StoneModelDescription : ScriptableObject
    {
        public float InteractionForceMultiplier;
        public float Mass;
        public int MaxHp;
    }
}
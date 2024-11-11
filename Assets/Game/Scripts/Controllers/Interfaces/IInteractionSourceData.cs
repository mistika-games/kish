using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface IInteractionSourceData
    {
        int SourceDamage { get; }
        Vector3 SourcePosition { get; }
        Vector2 SourceVelocity { get; }
        float SourceStrength { get; }
    }
}
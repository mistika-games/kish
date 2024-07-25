using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface IInteractionSourceData
    {
        Vector3 SourcePosition { get; }
        Vector2 SourceVelocity { get; }
    }
}
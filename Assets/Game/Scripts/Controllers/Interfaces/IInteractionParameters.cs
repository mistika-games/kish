using UnityEngine;

namespace Game.Scripts.Controllers.Interfaces
{
    public interface IInteractionParameters
    {
        IInteractionSourceData SourceData { get; }
        Vector3 InteractionPoint { get; }
    }
}
using Game.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace Game.Scripts.Structs
{
    public struct PhysicsInteractionParameters : IInteractionParameters
    {
        public IInteractionSourceData SourceData { get; internal set; }
        public Vector3 InteractionPoint { get;  internal set;}
    }
}
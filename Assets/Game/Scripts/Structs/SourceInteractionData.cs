﻿using Game.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace Game.Scripts.Structs
{
    public struct SourceInteractionData : IInteractionSourceData
    {
        public int SourceDamage { get; internal set; }
        public float SourceStrength { get; internal set; }
        public Vector3 SourcePosition { get; internal set; }
        public Vector2 SourceVelocity { get; internal set; }
    }
}
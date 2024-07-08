﻿using System;
using System.Runtime.InteropServices;

namespace Core.Unit
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public readonly struct Unit : IEquatable<Unit>
    {
        public bool Equals(Unit other) => true;

        public override bool Equals(object obj) => obj is Unit;

        public override int GetHashCode() => 0;

        public override string ToString() => "()";

        public static bool operator ==(Unit first, Unit second) => true;

        public static bool operator !=(Unit first, Unit second) => false;

        public static Unit unit => new Unit();
    }
}
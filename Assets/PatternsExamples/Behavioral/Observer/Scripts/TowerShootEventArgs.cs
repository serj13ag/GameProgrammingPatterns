using System;
using UnityEngine;

namespace PatternsExamples.Behavioral.Observer.Scripts
{
    public class TowerShootEventArgs : EventArgs
    {
        public Vector3 Position { get; }
        public Vector3 Direction { get; }
        public float ProjectileSpeed { get; }

        public TowerShootEventArgs(Vector3 position, Vector3 direction, float projectileSpeed)
        {
            Position = position;
            Direction = direction;
            ProjectileSpeed = projectileSpeed;
        }
    }
}
using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts.Terrains
{
    /// <summary>
    /// Shared intrinsic data
    /// </summary>
    public class FlyweightTerrainData
    {
        public int MovementCost { get; }
        public Material ColoringMaterial { get; }
        public ParticleSystem Particles { get; }

        public FlyweightTerrainData(int movementCost, Material coloringMaterial, ParticleSystem particles)
        {
            MovementCost = movementCost;
            ColoringMaterial = coloringMaterial;
            Particles = particles;
        }
    }
}
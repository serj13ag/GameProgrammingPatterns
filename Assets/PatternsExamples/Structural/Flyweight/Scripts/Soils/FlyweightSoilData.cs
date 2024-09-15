using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts.Soils
{
    /// <summary>
    /// Shared intrinsic data
    /// </summary>
    public class FlyweightSoilData
    {
        public int MovementCost { get; }
        public Material ColoringMaterial { get; }
        public ParticleSystem Particles { get; }

        public FlyweightSoilData(int movementCost, Material coloringMaterial, ParticleSystem particles)
        {
            MovementCost = movementCost;
            ColoringMaterial = coloringMaterial;
            Particles = particles;
        }
    }
}
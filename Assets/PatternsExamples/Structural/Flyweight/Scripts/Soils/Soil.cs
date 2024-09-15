using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts.Soils
{
    public class Soil : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private FlyweightSoilData _flyweightSoilData;

        public int MovementCost => _flyweightSoilData.MovementCost;
        public Material ColoringMaterial => _flyweightSoilData.ColoringMaterial;
        public ParticleSystem Particles => _flyweightSoilData.Particles;

        public void Init(FlyweightSoilData flyweightSoilData, Vector3 position)
        {
            _flyweightSoilData = flyweightSoilData;

            _meshRenderer.material = flyweightSoilData.ColoringMaterial;

            transform.position = position;
        }
    }
}
using System;
using System.Collections.Generic;
using PatternsExamples.Structural.Flyweight.Scripts.Soils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PatternsExamples.Structural.Flyweight.Scripts
{
    public class TerrainFactory : MonoBehaviour
    {
        [SerializeField] private Soil _soilPrefab;

        [SerializeField] private Material _grassMaterial;
        [SerializeField] private Material _mudMaterial;
        [SerializeField] private Material _sandMaterial;
        [SerializeField] private ParticleSystem _grassParticles;
        [SerializeField] private ParticleSystem _mudParticles;
        [SerializeField] private ParticleSystem _sandParticles;

        private Dictionary<SoilType, FlyweightSoilData> _flyweightSoilData;

        private void Awake()
        {
            _flyweightSoilData = new Dictionary<SoilType, FlyweightSoilData>()
            {
                { SoilType.Grass, new FlyweightSoilData(1, _grassMaterial, _grassParticles) },
                { SoilType.Mud, new FlyweightSoilData(2, _mudMaterial, _mudParticles) },
                { SoilType.Sand, new FlyweightSoilData(3, _sandMaterial, _sandParticles) },
            };
        }

        public Soil Create(Vector3Int position)
        {
            var randomSoilType = GetRandomSoilType();
            var flyweightSoilData = _flyweightSoilData[randomSoilType];

            var soil = Instantiate(_soilPrefab, position, _soilPrefab.transform.rotation);
            soil.Init(flyweightSoilData, position);

            return soil;
        }

        private static SoilType GetRandomSoilType()
        {
            var values = Enum.GetValues(typeof(SoilType));
            return (SoilType)values.GetValue(Random.Range(0, values.Length));
        }
    }
}
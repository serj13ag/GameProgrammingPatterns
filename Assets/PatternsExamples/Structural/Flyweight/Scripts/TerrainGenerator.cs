using System;
using System.Collections.Generic;
using PatternsExamples.Structural.Flyweight.Scripts.Terrains;
using UnityEngine;
using Random = System.Random;
using Terrain = PatternsExamples.Structural.Flyweight.Scripts.Terrains.Terrain;

namespace PatternsExamples.Structural.Flyweight.Scripts
{
    public class TerrainGenerator : MonoBehaviour
    {
        [SerializeField] private Terrain _terrainPrefab;

        [SerializeField] private Material _grassMaterial;
        [SerializeField] private Material _mudMaterial;
        [SerializeField] private Material _sandMaterial;
        [SerializeField] private ParticleSystem _grassParticles;
        [SerializeField] private ParticleSystem _mudParticles;
        [SerializeField] private ParticleSystem _sandParticles;

        private readonly Dictionary<Vector3Int, Terrain> _terrain = new Dictionary<Vector3Int, Terrain>();

        private Dictionary<TerrainType, FlyweightTerrainData> _flyweightTerrainData;

        private void Awake()
        {
            _flyweightTerrainData = new Dictionary<TerrainType, FlyweightTerrainData>()
            {
                { TerrainType.Grass, new FlyweightTerrainData(1, _grassMaterial, _grassParticles) },
                { TerrainType.Mud, new FlyweightTerrainData(2, _mudMaterial, _mudParticles) },
                { TerrainType.Sand, new FlyweightTerrainData(3, _sandMaterial, _sandParticles) },
            };
        }

        private void Start()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    var position = new Vector3Int(x, y, 0);
                    var randomTerrainType = GetRandomTerrainType();
                    var flyweightTerrainData = _flyweightTerrainData[randomTerrainType];

                    var terrain = Instantiate(_terrainPrefab, position, _terrainPrefab.transform.rotation);
                    terrain.Init(flyweightTerrainData, position);
                    _terrain[position] = terrain;
                }
            }
        }

        public bool TryGetTerrain(Vector3Int position, out Terrain terrain)
        {
            return _terrain.TryGetValue(position, out terrain);
        }

        private static TerrainType GetRandomTerrainType()
        {
            var values = Enum.GetValues(typeof(TerrainType));
            var random = new Random();
            return (TerrainType)values.GetValue(random.Next(values.Length));
        }
    }
}
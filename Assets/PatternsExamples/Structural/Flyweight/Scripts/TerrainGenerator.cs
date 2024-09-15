using System.Collections.Generic;
using PatternsExamples.Structural.Flyweight.Scripts.Soils;
using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts
{
    public class TerrainGenerator : MonoBehaviour
    {
        [SerializeField] private TerrainFactory _terrainFactory;

        private readonly Dictionary<Vector3Int, Soil> _terrain = new Dictionary<Vector3Int, Soil>();

        private void Start()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    var position = new Vector3Int(x, y, 0);

                    var soil = _terrainFactory.Create(position);
                    _terrain[position] = soil;
                }
            }
        }

        public bool TryGetSoil(Vector3Int position, out Soil soil)
        {
            return _terrain.TryGetValue(position, out soil);
        }
    }
}
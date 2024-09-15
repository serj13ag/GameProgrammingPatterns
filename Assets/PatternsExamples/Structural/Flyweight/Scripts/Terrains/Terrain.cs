using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts.Terrains
{
    public class Terrain : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private FlyweightTerrainData _flyweightTerrainData;

        public int MovementCost => _flyweightTerrainData.MovementCost;
        public Material ColoringMaterial => _flyweightTerrainData.ColoringMaterial;
        public ParticleSystem Particles => _flyweightTerrainData.Particles;

        public void Init(FlyweightTerrainData flyweightTerrainData, Vector3 position)
        {
            _flyweightTerrainData = flyweightTerrainData;

            _meshRenderer.material = flyweightTerrainData.ColoringMaterial;

            transform.position = position;
        }
    }
}
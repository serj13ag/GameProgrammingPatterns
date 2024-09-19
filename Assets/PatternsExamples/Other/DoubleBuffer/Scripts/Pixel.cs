using System;
using UnityEngine;

namespace PatternsExamples.Other.DoubleBuffer.Scripts
{
    public class Pixel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _whiteMaterial;
        [SerializeField] private Material _blackMaterial;
        [SerializeField] private ParticleSystem _updatedParticles;

        public Color CurrentColor { get; private set; }

        private void Awake()
        {
            SetColor(Color.White);
        }

        public void SetColor(Color color)
        {
            CurrentColor = color;

            _meshRenderer.material = color switch
            {
                Color.White => _whiteMaterial,
                Color.Black => _blackMaterial,
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
            };

            Instantiate(_updatedParticles, transform.position, _updatedParticles.transform.rotation);
        }
    }
}
using UnityEngine;

namespace PatternsExamples.Structural.Flyweight.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TerrainGenerator _terrainGenerator;
        [SerializeField] private MeshRenderer _meshRenderer;

        private Vector3Int _currentPosition;

        private void Awake()
        {
            UpdatePosition(Vector3Int.zero);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector3Int.up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector3Int.down);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector3Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector3Int.right);
            }
        }

        private void Move(Vector3Int direction)
        {
            if (_terrainGenerator.TryGetSoil(_currentPosition, out var moveFromSoil))
            {
                Debug.Log($"Movement cost: {moveFromSoil.MovementCost}");
            }

            UpdatePosition(_currentPosition + direction);

            if (_terrainGenerator.TryGetSoil(_currentPosition, out var moveToSoil))
            {
                _meshRenderer.material = moveToSoil.ColoringMaterial;

                Instantiate(moveToSoil.Particles, _currentPosition, Quaternion.identity);
            }
        }

        private void UpdatePosition(Vector3Int position)
        {
            _currentPosition = position;
            transform.position = _currentPosition;
        }
    }
}
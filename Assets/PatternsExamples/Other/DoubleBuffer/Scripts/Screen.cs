using UnityEngine;

namespace PatternsExamples.Other.DoubleBuffer.Scripts
{
    public class Screen : MonoBehaviour
    {
        private const int ScreenSide = 6;

        [SerializeField] private Pixel _pixelPrefab;
        [SerializeField] private float _refreshRate;

        [SerializeField] private DrawBuffer _drawBuffer;

        private Pixel[] _pixels;
        private float _timeTillRefresh;

        private void Awake()
        {
            _drawBuffer.Init(ScreenSide);
            _pixels = Helpers.CreateScreen(ScreenSide, _pixelPrefab, transform.position);

            _timeTillRefresh = _refreshRate;
        }

        private void Update()
        {
            if (_timeTillRefresh > 0f)
            {
                _timeTillRefresh -= Time.deltaTime;
            }
            else
            {
                Refresh();
                _timeTillRefresh = _refreshRate;
            }
        }

        private void Refresh()
        {
            var bufferPixels = _drawBuffer.Get();

            for (var i = 0; i < _pixels.Length; i++)
            {
                var bufferPixelColor = bufferPixels[i].CurrentColor;
                _pixels[i].SetColor(bufferPixelColor);
            }
        }
    }
}
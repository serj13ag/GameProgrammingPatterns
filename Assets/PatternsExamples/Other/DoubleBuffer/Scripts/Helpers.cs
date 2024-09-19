using UnityEngine;

namespace PatternsExamples.Other.DoubleBuffer.Scripts
{
    public static class Helpers
    {
        private const int PixelOffset = 1;

        public static readonly int[] SmileFaceImage = new int[]
        {
            0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 1, 0,
            0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 1, 0,
            0, 0, 1, 1, 0, 0,
            0, 0, 0, 0, 0, 0,
        };

        public static readonly int[] SadFaceImage = new int[]
        {
            0, 0, 0, 0, 0, 0,
            0, 1, 0, 0, 1, 0,
            0, 0, 0, 0, 0, 0,
            0, 0, 1, 1, 0, 0,
            0, 1, 0, 0, 1, 0,
            0, 0, 0, 0, 0, 0,
        };

        public static Pixel[] CreateScreen(int side, Pixel pixelPrefab, Vector3 parentPosition)
        {
            var pixels = new Pixel[side * side];

            for (var row = 0; row < side; row++)
            {
                for (var col = 0; col < side; col++)
                {
                    var position = new Vector2(parentPosition.x + col * PixelOffset, parentPosition.y - row * PixelOffset);
                    var pixel = Object.Instantiate(pixelPrefab, position, pixelPrefab.transform.rotation);

                    var index = row * side + col;
                    pixels[index] = pixel;
                }
            }

            return pixels;
        }
    }
}
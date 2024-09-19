using System;
using UnityEngine;

namespace PatternsExamples.Other.DoubleBuffer.Scripts
{
    public class DrawBuffer : MonoBehaviour
    {
        [SerializeField] private Pixel _pixelPrefab;
        [SerializeField] private float _computeSpeed;
        [SerializeField] private bool _useDoubleBuffer;

        private Pixel[] _pixels;
        private Pixel[] _pixelsSecond;

        private Pixel[][] _buffers;
        private int _readyBufferIndex;
        private int _workingBufferIndex;

        private bool _useSadFaceImage;
        private int _pixelIndexToUpdate;
        private float _timeTillUpdateNextPixel;

        public void Init(int side)
        {
            _pixels = Helpers.CreateScreen(side, _pixelPrefab, transform.position);
            _pixelsSecond = Helpers.CreateScreen(side, _pixelPrefab, transform.position + Vector3.right * 7);

            _buffers = new Pixel[][] { _pixels, _pixelsSecond };
            _readyBufferIndex = 0;
            _workingBufferIndex = 0;

            _timeTillUpdateNextPixel = _computeSpeed;
        }

        private void Update()
        {
            if (_timeTillUpdateNextPixel > 0f)
            {
                _timeTillUpdateNextPixel -= Time.deltaTime;
            }
            else
            {
                var currentBuffer = _useDoubleBuffer ? _buffers[_workingBufferIndex] : _buffers[0];

                var imageToDraw = _useSadFaceImage ? Helpers.SadFaceImage : Helpers.SmileFaceImage;
                var pixelColor = imageToDraw[_pixelIndexToUpdate] == 1 ? Color.Black : Color.White;
                currentBuffer[_pixelIndexToUpdate].SetColor(pixelColor);

                _pixelIndexToUpdate++;
                if (_pixelIndexToUpdate > currentBuffer.Length - 1)
                {
                    _pixelIndexToUpdate = 0;
                    SwapRenderedImage();

                    if (_useDoubleBuffer)
                    {
                        SwapBuffers();
                    }
                }

                _timeTillUpdateNextPixel = _computeSpeed;
            }
        }

        private void SwapRenderedImage()
        {
            _useSadFaceImage = !_useSadFaceImage;
        }

        public Pixel[] Get()
        {
            return _useDoubleBuffer ? _buffers[_readyBufferIndex] : _buffers[0];
        }

        private void SwapBuffers()
        {
            _readyBufferIndex = _workingBufferIndex;

            _workingBufferIndex = _workingBufferIndex switch
            {
                0 => 1,
                1 => 0,
                _ => throw new IndexOutOfRangeException()
            };
        }
    }
}
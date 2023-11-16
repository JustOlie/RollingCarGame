using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField, Range(3f, 100f)] private int _levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float _xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float _yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] private float _curveSmoothness = 0.5f;

    // Assuming you have a reference to SpriteShapeController
    public SpriteShapeController _spriteShapeController;

    // Assuming _noiseStep is a variable controlling Perlin noise frequency
    private float _noiseStep = 0.1f;

    // Assuming _bottom is the depth of the terrain
    private float _bottom = 5f;

    private void OnValidate()
    {
        // Check if SpriteShapeController is assigned
        if (_spriteShapeController == null)
        {
            Debug.LogError("SpriteShapeController is not assigned.");
            return;
        }

        _spriteShapeController.spline.Clear();

        Vector3 _lastPos = Vector3.zero; // Initialize _lastPos

        for (int i = 0; i < _levelLength; i++)
        {
            // Use Perlin noise for the terrain height
            float noiseValue = Mathf.PerlinNoise(i * _noiseStep, 0);
            _lastPos = transform.position + new Vector3(i * _xMultiplier, noiseValue * _yMultiplier, 0);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);
            
            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        // Assuming you want to create a bottom part of the terrain
        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom, 0));
        _spriteShapeController.spline.InsertPointAt(_levelLength + 10, new Vector3(_lastPos.x, transform.position.y - _bottom, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem pSystem = null;
    private ParticleSystem.ShapeModule _shape;
    private Vector3 _defaultShapeRotation;
    private Vector3 _rotationDiff;
    
    void Start()
    {
        _shape = pSystem.shape;
        _defaultShapeRotation = _shape.rotation;
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        _rotationDiff.x = verticalInput * 60;
        _rotationDiff.y = horizontalInput * 60;

        _shape.rotation = _defaultShapeRotation + _rotationDiff;
    }
}

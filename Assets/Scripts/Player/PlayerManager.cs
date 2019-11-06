using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _movementVelocity = 0.1f;
    private float _rotationSensitivity = 2f;
    private float _jumpVelocity = 0.5f;
    private float _boostVelocity = 1f;

    private Transform _playerTransform;
    private Rigidbody _rigidbody;
    private Vector3 _movementTarget = Vector3.zero;

    void Start()
    {
        _playerTransform = this.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var currentPosition = _playerTransform.position;
        var movementY = currentPosition.y;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0 || horizontalInput > 0)
        {
            _movementTarget += _playerTransform.right * (_movementVelocity * Mathf.Sign(horizontalInput));
        }

        if (verticalInput < 0 || verticalInput > 0)
        {
            _movementTarget += _playerTransform.forward * (_movementVelocity * Mathf.Sign(verticalInput));
        }
        
        _movementTarget.y = currentPosition.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(0, _jumpVelocity, 0, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(0, _boostVelocity, 0, ForceMode.VelocityChange);
        }

        var mouseX = Input.GetAxis("Mouse X") * _rotationSensitivity;
        var mouseY = Input.GetAxis("Mouse Y") * _rotationSensitivity * -1;
        
        _playerTransform.Rotate(mouseY, mouseX, 0);
        
        _playerTransform.position = Vector3.Lerp(_playerTransform.position, _movementTarget, 0.4f);
    }
}

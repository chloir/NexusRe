using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _cameraTransform;
    private Transform _targetTransform;

    private Vector3 _cameraTargetPosition;
    
    void Start()
    {
        _cameraTransform = this.transform;
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _targetTransform = GameObject.FindWithTag("CameraTarget").GetComponent<Transform>();
    }

    void Update()
    {
        var playerPosition = _playerTransform.position;
        var targetPosition = _targetTransform.position;

        _cameraTargetPosition = targetPosition;

        var distance = Vector3.Distance(playerPosition, targetPosition);
        var direction = targetPosition - playerPosition;
        
        RaycastHit hitInfo;
        
        if (Physics.Raycast(playerPosition, direction, out hitInfo, distance))
        {
            _cameraTargetPosition = hitInfo.point;
        }
        
        _cameraTransform.LookAt(_playerTransform);

        Vector3 diff = (_cameraTargetPosition - _cameraTransform.position) * 0.6f;
        
        _cameraTransform.position += diff;
    }
}

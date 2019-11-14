using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    private GameObject _player;
    private float _movementVelocity = 2f;
    private Vector3 _playerPosition;
    private Vector3 _targetPosition;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        _playerPosition = _player.transform.position;

        _targetPosition = _playerPosition + new Vector3(
                              Random.Range(-1.5f, 1.5f), 
                              Random.Range(-1.5f, 1.5f), 
                              Random.Range(-1.5f, 1.5f));

        transform.position = Vector3.Lerp(transform.position, _targetPosition, 0.2f);
    }
}

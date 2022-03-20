using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _startPos;
    [SerializeField] private float _speed = 1f;
    private Vector2 _nextPos;

    [SerializeField] private PlayerController player;

    private void Start()
    {
        _nextPos = _startPos.position;
    }

    void Update()
    {
        if(transform.position == _point1.position)
        {
            _nextPos = _point2.position;
        }
        if (transform.position == _point2.position)
        {
            _nextPos = _point1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.Respawn();
        }
    }
}

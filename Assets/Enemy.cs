using Managers;
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
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _nextPos = _startPos.position;
    }

    void Update()
    {
        //APPARENCE
        if (AbilitiesManager.instance.IsAbilityActive(EAbilities.CONTRAST))
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }

        //POSITION
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _player.position = transform.position;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borb : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] Vector2 Dir;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rb.AddForce(Dir, ForceMode2D.Impulse);
            Destroy(gameObject, 10f);
        }
    }
}

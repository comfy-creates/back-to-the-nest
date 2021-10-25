using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    PlayerController _controller;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _controller = GetComponentInParent<PlayerController>();
            _controller._canJump = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _startPosX, _startPosY;
    [SerializeField] float ParallaxEffectX, ParallaxEffectY;

    [SerializeField] Transform Cam;

    private void Start()
    {
        _startPosX = transform.position.x;
        _startPosY = transform.position.y;
    }

    private void Update()
    {
        float distX = (Cam.transform.position.x * ParallaxEffectX);
        float distY = (Cam.transform.position.y * ParallaxEffectY);

        transform.position = new Vector3(_startPosX + distX, _startPosY + distY);
    }
}

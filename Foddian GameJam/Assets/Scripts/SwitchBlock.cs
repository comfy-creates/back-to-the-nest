using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwitchBlock : MonoBehaviour
{
    [SerializeField] float StartDelay;
    [SerializeField] float MainDelay;
    float _curDelay;

    [SerializeField] bool Open;
    Collider2D _col;
    SpriteRenderer _sr;

    bool _firstFrame, _endFrame;

    Vector3 _baseScale;

    private void Awake()
    {
        _baseScale = transform.localScale;
    }

    private void Start()
    {
        _curDelay = StartDelay;
        transform.localScale = Vector3.zero;

        _col = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Open)
        {
            if (!_firstFrame)
            {
                _endFrame = false;
                transform.DOScaleX(_baseScale.x, 0.25f);
                transform.DOScaleY(_baseScale.y, 0.25f);

                _firstFrame = true;
            }

            _col.enabled = true;
            _sr.enabled = true;
        }
        else
        {
            if (!_endFrame)
            {
                transform.DOScaleX(0, 0.25f);
                transform.DOScaleY(0, 0.25f);

                _endFrame = true;
            }
            _firstFrame = false;
            _col.enabled = false;
            _sr.enabled = false;
        }
        if(_curDelay <= 0)
        {
            Open = !Open;
            _curDelay = MainDelay;
        }
        else
        {
            _curDelay -= Time.deltaTime;
        }
    }
}

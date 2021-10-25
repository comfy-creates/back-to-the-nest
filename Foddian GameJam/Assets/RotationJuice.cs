using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationJuice : MonoBehaviour
{
    Tween _a, _b;

    private void OnEnable()
    {
        _a.Kill(true);
        _b.Kill(true);
        _a = transform.DOScale(1.2f, 0.1f);
        Invoke(nameof(A), 0.1f);
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(0.6f, 0.6f);
    }

    private void A()
    {
        _b = transform.DOScale(1f, 0.15f);

    }
}

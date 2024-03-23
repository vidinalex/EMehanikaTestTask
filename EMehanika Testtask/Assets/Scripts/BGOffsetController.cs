using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGOffsetController : MonoBehaviour
{
    [SerializeField] private RawImage _bgRaw;
    [SerializeField] private float _translateSpeed, _maxOffset;

    private Vector2 _uvRectTarget = Vector2.zero;
    private float currTime;

    private void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0)
        {
            currTime = _translateSpeed;
            GenerateUVTarget();
        }

        _bgRaw.uvRect = new Rect(Vector2.Lerp(_bgRaw.uvRect.position, _uvRectTarget, _translateSpeed * Time.deltaTime), Vector2.one);
    }

    private void GenerateUVTarget()
    {
        _uvRectTarget = new Vector2(Random.Range(-_maxOffset, _maxOffset), Random.Range(-_maxOffset, _maxOffset));
    }
}

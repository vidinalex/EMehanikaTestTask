using System;
using UnityEngine;

public class ElipsePathFollower : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _selfSR;
    [SerializeField]
    private Transform _elipseCenter;
    [SerializeField]
    private float _initialSpeed;
    [SerializeField]
    private float _radius;
    [SerializeField]
    private float _zElipseOffset;
    [SerializeField]
    private Vector3 _offset;

    private float _angle;

    private void Update()
    {
        ApplyMove();
        ApplyRotation();
    }
    private void ApplyMove() // движение по окружности с поправкой на "овальность"
    {
        Vector3 targetPos = new Vector3(
            _elipseCenter.position.x + Mathf.Cos(_angle) * _radius,
            transform.position.y,
            _elipseCenter.position.z + Mathf.Sin(_angle) * _radius * _zElipseOffset) + _offset;

        transform.position = targetPos;

        _angle += -_initialSpeed * LevelInputManager.Default.GetCurrentSpeedMod() * Time.deltaTime;
    }

    private float _lastXPos;
    private void ApplyRotation()
    {
        if (_lastXPos > transform.position.x)
        {
            _selfSR.flipX = false;
        }
        else
        {
            _selfSR.flipX = true;
        }

        _lastXPos = transform.position.x;
    }

    
}

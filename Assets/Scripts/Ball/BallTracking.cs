using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffSet;
    [SerializeField] private float _length;
    
    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPos;

    public void Check()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPos = _ball.transform.position;
        
        TrackBall();
    }

    private void Update()
    {
        if (_ball != null)
        {
            if (_ball.transform.position.y < _minimumBallPos.y)
            {
                TrackBall();
                _minimumBallPos = _ball.transform.position;
            }   
        }
    }

    private void TrackBall()
    {
        Vector3 beamPos = _beam.transform.position;
        beamPos.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPos - _ball.transform.position).normalized + _directionOffSet;
        _cameraPosition -= direction * _length;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}

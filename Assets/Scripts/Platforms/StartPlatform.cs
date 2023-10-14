using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class StartPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;

    private void Awake()
    {
        Instantiate(_ball, _spawnPoint.position, UnityEngine.Quaternion.identity);
    }
}

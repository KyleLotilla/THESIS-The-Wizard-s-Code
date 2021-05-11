﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnGameObjectDestroy();

public class DestroyHandler : MonoBehaviour
{
    public event OnGameObjectDestroy OnGameObjectDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        OnGameObjectDestroy?.Invoke();
        OnGameObjectDestroy = null;
    }
}
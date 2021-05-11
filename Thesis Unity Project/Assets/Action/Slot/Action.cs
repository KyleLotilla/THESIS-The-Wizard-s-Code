﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnExecutionStart();
public delegate void OnExecutionEnd();

public class Action : MonoBehaviour
{
    public event OnExecutionStart OnExecutionStart;
    public event OnExecutionEnd OnExecutionEnd;
    public bool isExecuting { get; set; } = false;
    [SerializeField]
    private bool _isMovement = false;
    public bool isMovement
    {
        get
        {
            return _isMovement;
        }
        set
        {
            _isMovement = value;
        }
    }
    public GameObject wizard { get; set; }
    protected virtual void Execute()
    {

    }

    public void StartExecution()
    {
        isExecuting = true;
        Execute();
        if (isExecuting)
        {
            OnExecutionStart?.Invoke();
        }
    }

    public void EndExecution()
    {
        isExecuting = false;
        OnExecutionEnd?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnExecutionStart();
public delegate void OnExecutionEnd();

public class Action : MonoBehaviour
{
    public event OnExecutionStart OnExecutionStart;
    public event OnExecutionEnd OnExecutionEnd;
    public Spell spell { get; set; }
    public bool isExecuting { get; set; } = false;
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCodeAction : Action
{
    public event OnSingleActionExecutionStart OnSingleActionExecutionStart;
    public event OnSingleActionExecutionEnd OnSingleActionExecutionEnd;

    [SerializeField]
    private SpellCode _spellCode;
    public SpellCode spellCode
    {
        get
        {
            return _spellCode;
        }
        set
        {
            _spellCode = value;
        }
    }
    [SerializeField]
    private ActionSequence actionSequence;
    [SerializeField]
    private List<GameObject> _actionPrefabs;
    public List<GameObject> actionPrefabs
    {
        get
        {
            return _actionPrefabs;
        }
        set
        {
            _actionPrefabs = value;
            List<Action> actions = new List<Action>();
            if (_actionPrefabs != null)
            {
                foreach (GameObject actionPrefab in _actionPrefabs)
                {
                    GameObject actionObject = Instantiate(actionPrefab, this.transform);
                    if (actionObject != null)
                    {
                        Action action = actionObject.GetComponent<Action>();
                        if (action != null)
                        {
                            actions.Add(action);
                        }
                    }
                }
                actionSequence.actions = actions;
            }
        }
    }

    protected override void Execute()
    {
        actionSequence.wizard = wizard;
        actionSequence.StartExecution();
    }

    void Start()
    {
        actionSequence.OnExecutionEnd += OnSequenceExecutionEnd;
        actionSequence.OnSingleActionExecutionStart += OnSequenceActionExecutionStart;
        actionSequence.OnSingleActionExecutionEnd += OnSequenceActionExecutionEnd;
    }

    void Update()
    {
        
    }

    void OnSequenceExecutionEnd()
    {
        EndExecution();
    }

    private void OnSequenceActionExecutionStart(int actionIndex)
    {
        OnSingleActionExecutionStart?.Invoke(actionIndex);
    }

    void OnSequenceActionExecutionEnd(int actionIndex)
    {
        OnSingleActionExecutionEnd?.Invoke(actionIndex);
    }
}
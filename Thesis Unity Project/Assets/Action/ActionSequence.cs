using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnSingleActionExecutionStart(int actionIndex);
public delegate void OnSingleActionExecutionEnd(int actionIndex);

public class ActionSequence : MonoBehaviour
{
    public OnExecutionEnd OnExecutionEnd;
    public OnSingleActionExecutionStart OnSingleActionExecutionStart;
    public OnSingleActionExecutionEnd OnSingleActionExecutionEnd;

    [SerializeField]
    private GameObject _wizard;
    public GameObject wizard
    {
        get
        {
            return _wizard;
        }
        set
        {
            _wizard = value;
        }
    }

    [SerializeField]
    private List<Action> _actions;
    public List<Action> actions
    {
        get
        {
            return _actions;
        }
        set
        {
            _actions = value;
        }
    }
    public bool isExecuting { get; set; } = false;
    private int currentAction = 0;

    public void StartExecution()
    {
        currentAction = 0;
        ExecuteNextAction();
    }

    void ExecuteNextAction()
    {
        if (currentAction < actions.Count)
        {
            isExecuting = true;
            actions[currentAction].wizard = wizard;
            actions[currentAction].OnExecutionEnd += OnActionExecutionEnd;
            OnSingleActionExecutionStart?.Invoke(currentAction);
            actions[currentAction].StartExecution();
        }
        else
        {
            isExecuting = false;
            OnExecutionEnd?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnActionExecutionEnd()
    {
        actions[currentAction].OnExecutionEnd -= OnActionExecutionEnd;
        OnSingleActionExecutionEnd?.Invoke(currentAction);
        currentAction++;
        ExecuteNextAction();
    }
}

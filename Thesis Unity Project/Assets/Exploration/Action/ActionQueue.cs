using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionQueue : MonoBehaviour
{
    public event OnExecutionEnd OnExecutionEnd;

    [SerializeField] 
    private GameObject wizard;
    [SerializeField] 
    private List<QueueSpaceHandler> queueSpaces;
    [SerializeField]
    private int currentAction;
    private ActionSlot currentActionSlot;
    public bool isExecuting { get; set; }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartExecution()
    {
        currentAction = 0;
        ExecuteNextAction();
    }

    void ExecuteNextAction()
    {
        bool foundAction = false;
        for (; currentAction < queueSpaces.Count && !foundAction; currentAction++)
        {
            if (queueSpaces[currentAction].isFilled())
            {
                foundAction = true;
                break;
            }
        }

        if (foundAction)
        {
            isExecuting = true;
            currentActionSlot = queueSpaces[currentAction].GetActionSlot();
            currentActionSlot.action.OnExecutionEnd += OnActionExecutionEnd;
            currentActionSlot.action.wizard = wizard;
            currentActionSlot.action.StartExecution();
        }
        else
        {
            isExecuting = false;
            OnExecutionEnd?.Invoke();
        }
    }

    void OnActionExecutionEnd()
    {
        currentActionSlot.action.OnExecutionEnd -= OnActionExecutionEnd;
        currentActionSlot = null;
        queueSpaces[currentAction].ConsumeSlot();
        currentAction++;
        ExecuteNextAction();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionQueue : MonoBehaviour
{
    public event OnExecutionEnd OnExecutionEnd;

    [SerializeField] 
    private GameObject wizard;
    [SerializeField] 
    private List<QueueDropSpace> queueSlotSpaces;
    [SerializeField]
    private int currentAction;
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
        for (; currentAction < queueSlotSpaces.Count && !foundAction; currentAction++)
        {
            if (queueSlotSpaces[currentAction].slot != null)
            {
                foundAction = true;
                break;
            }
        }

        if (foundAction)
        {
            isExecuting = true;
            queueSlotSpaces[currentAction].stackActionSlot.action.OnExecutionEnd += OnActionExecutionEnd;
            queueSlotSpaces[currentAction].stackActionSlot.action.wizard = wizard;
            queueSlotSpaces[currentAction].stackActionSlot.action.StartExecution();
        }
        else
        {
            isExecuting = false;
            OnExecutionEnd?.Invoke();
        }
    }

    void OnActionExecutionEnd()
    {
        queueSlotSpaces[currentAction].stackActionSlot.action.OnExecutionEnd -= OnActionExecutionEnd;
        queueSlotSpaces[currentAction].ConsumeSlot();
        currentAction++;
        ExecuteNextAction();
    }
}

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
    private ActionStack actionStack;
    private List<ActionSlot> actionSlots;

    public bool isExecuting { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        actionSlots = new List<ActionSlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartExecution()
    {
        foreach (QueueDropSpace slotSpace in queueSlotSpaces)
        {
            GameObject slot = slotSpace.slot;
            if (slot != null)
            {
                ActionSlot actionSlot = slot.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    actionSlots.Add(actionSlot);
                }
            }
        }

        if (actionSlots.Count > 0)
        {
            isExecuting = true;
            ExecuteAction();
        }
    }

    void ExecuteAction()
    {
        if (actionSlots.Count > 0)
        {
            actionSlots[0].action.wizard = wizard;
            actionSlots[0].action.StartExecution();
            actionSlots[0].action.OnExecutionEnd += OnActionExecutionEnd;
        }
    }

    void OnActionExecutionEnd()
    {
        actionSlots[0].action.OnExecutionEnd -= OnActionExecutionEnd;
        actionStack.DeleteAction(actionSlots[0].slotID);
        actionSlots[0].NofityContainerChange(null);
        DestroyImmediate(actionSlots[0].gameObject);
        actionSlots.RemoveAt(0);
        
        if (actionSlots.Count > 0)
        {
            ExecuteAction();
        }
        else
        {
            OnExecutionEnd?.Invoke();
        }
    }
}

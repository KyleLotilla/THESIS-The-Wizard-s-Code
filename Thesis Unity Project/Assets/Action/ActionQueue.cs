using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionQueue : MonoBehaviour
{
    public event OnExecutionEnd OnExecutionEnd;

    [SerializeField]
    private SpellCodeQueue spellCodeQueue;
    [SerializeField]
    private ActionSequence actionSequence;
    [SerializeField] 
    private List<QueueSpace> queueSpaces;
    [SerializeField]
    private List<SlotSpace> spaces;
    [SerializeField]
    private List<int> executingSpaceIndices;
    private List<Action> actions;
    public bool isExecuting { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        actionSequence.OnSingleActionExecutionStart += OnSequenceActionExecutionStart;
        actionSequence.OnSingleActionExecutionEnd += OnSequenceActionExecutionEnd;
        actionSequence.OnExecutionEnd += OnSequenceExecutionEnd;
        executingSpaceIndices = new List<int>();
        actions = new List<Action>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartExecution()
    {
        executingSpaceIndices.Clear();
        actions.Clear();
        for (int i = 0; i < spaces.Count; i++)
        {
            if (!spaces[i].isEmpty)
            {
                ActionSlot actionSlot = spaces[i].slot.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    actions.Add(actionSlot.action);
                    executingSpaceIndices.Add(i);
                }
            }
        }
        actionSequence.actions = actions;
        actionSequence.StartExecution();
    }

    void OnSequenceActionExecutionStart(int actionIndex)
    {
        if (actions[actionIndex].tag == "SpellCodeAction")
        {
            SpellCodeAction spellCodeAction = actions[actionIndex].gameObject.GetComponent<SpellCodeAction>();
            if (spellCodeAction != null)
            {
                spellCodeQueue.spellCodeAction = spellCodeAction;
                spellCodeQueue.gameObject.SetActive(true);
            }
        }
    }

    void OnSequenceActionExecutionEnd(int actionIndex)
    {
        int currentSpace = executingSpaceIndices[actionIndex];
        queueSpaces[currentSpace].ConsumeSlot();
        if (spellCodeQueue.gameObject.activeSelf)
        {
            spellCodeQueue.gameObject.SetActive(false);
        }
    }

    void OnSequenceExecutionEnd()
    {
        isExecuting = false;
        OnExecutionEnd?.Invoke();
    }
}

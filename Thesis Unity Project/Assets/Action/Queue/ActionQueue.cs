using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionQueue : MonoBehaviour
{
    public event OnExecutionEnd OnExecutionEnd;

    [SerializeField]
    private SpellCodeQueue spellCodeQueue;
    [SerializeField]
    private ActionSequence actionSequence;
    [SerializeField]
    private List<GameObject> spaceObjects;
    [SerializeField]
    private Button runButton;
    [SerializeField]
    private Button zoomOutButton;
    [SerializeField]
    private Button resetButton;
    [SerializeField]
    private ExplorationHoverHandler explorationHoverHandler;
    private List<int> executingSpaceIndices;
    private List<Action> actions;
    [SerializeField]
    private bool isTutorial = false;
    public bool isExecuting { get; set; }

    [SerializeField]
    private Moves moves;
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
        for (int i = 0; i < spaceObjects.Count; i++)
        {
            SlotSpace space = spaceObjects[i].GetComponent<SlotSpace>();
            if (!space.isEmpty)
            {
                ActionSlot actionSlot = space.slot.GetComponent<ActionSlot>();
                if (actionSlot != null)
                {
                    actions.Add(actionSlot.action);
                    executingSpaceIndices.Add(i);
                }
            }
            /*
            Draggable draggable = spaceObjects[i].GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.isDraggable = false;
            }
            */
            Droppable droppable = spaceObjects[i].GetComponent<Droppable>();
            if (droppable != null)
            {
                droppable.isDroppable = false;
            }
            RemoveSlotButtonHandler removeSlotButtonHandler = spaceObjects[i].GetComponent<RemoveSlotButtonHandler>();
            if (removeSlotButtonHandler != null)
            {
                removeSlotButtonHandler.SetButtonActive(false);
            }
        }
        runButton.interactable = false;
        zoomOutButton.interactable = false;
        resetButton.interactable = false;
        explorationHoverHandler.ClearCurrentHover();
        explorationHoverHandler.isHoverActive = false;
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
        int currentSpace = executingSpaceIndices[actionIndex];
        SpaceHiglighter queueSpaceColorHandler = spaceObjects[currentSpace].GetComponent<SpaceHiglighter>();
        if (queueSpaceColorHandler)
        {
            queueSpaceColorHandler.HighlightSpace();
        }
    }

    void OnSequenceActionExecutionEnd(int actionIndex)
    {
        int currentSpace = executingSpaceIndices[actionIndex];
        QueueSpace queueSpace = spaceObjects[currentSpace].GetComponent<QueueSpace>();
        if (queueSpace != null)
        {
            queueSpace.ConsumeSlot();
        }
        SpaceHiglighter queueSpaceColorHandler = spaceObjects[currentSpace].GetComponent<SpaceHiglighter>();
        if (queueSpaceColorHandler)
        {
            queueSpaceColorHandler.UnhighlightSpace();
        }
        if (spellCodeQueue.gameObject.activeSelf)
        {
            spellCodeQueue.gameObject.SetActive(false);
        }
        this.moves.MoveUsed();
    }

    void OnSequenceExecutionEnd()
    {
        for (int i = 0; i < spaceObjects.Count; i++)
        {
            /*
            Draggable draggable = spaceObjects[i].GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.isDraggable = true;
            }
            */
            Droppable droppable = spaceObjects[i].GetComponent<Droppable>();
            if (droppable != null)
            {
                droppable.isDroppable = true;
            }
        }
        runButton.interactable = true;
        explorationHoverHandler.isHoverActive = true;
        if (!isTutorial)
        {
            zoomOutButton.interactable = true;
            resetButton.interactable = true;
        }
        isExecuting = false;
        OnExecutionEnd?.Invoke();
    }
}

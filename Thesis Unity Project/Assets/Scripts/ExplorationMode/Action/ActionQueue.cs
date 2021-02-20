using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    [SerializeField] private GameObject wizard;
    [SerializeField] private GameObject slots;
    [SerializeField] private List<Action> actions;
    public bool isExecuting { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (actions[0].isFinishedExecuting())
        {
            Destroy(actions[0].gameObject);
            actions.RemoveAt(0);

            if (actions.Count == 0)
            {
                foreach (Transform slot in slots.transform)
                {
                    ExecutionDropHandler dropHandler = slot.GetComponent<ExecutionDropHandler>();
                    if (dropHandler)
                    {
                        dropHandler.canDrop = true;
                        dropHandler.occupied = false;
                    }
                }
                this.isExecuting = false;
                this.enabled = false;
            }
            else
            {
                actions[0].Execute();
            }
        }
    }

    public void ExecuteActions()
    {
        Debug.Log("Executing actions");
        foreach(Transform slot in slots.transform)
        {
            ExecutionDropHandler dropHandler = slot.GetComponent<ExecutionDropHandler>();
            if (dropHandler)
            {
                dropHandler.canDrop = false;
            }

            if (slot.transform.childCount > 0)
            {
                GameObject child = slot.GetChild(0).gameObject;
                if (child)
                {
                    Action action = child.GetComponent<Action>();
                    if (action)
                    {
                        action.Wizard = this.wizard;
                        this.actions.Add(action);
                    }
                }
            }
            
        }

        if (this.actions.Count > 0)
        {
            this.enabled = true;
            actions[0].Execute();
        }
        else
        {
            foreach (Transform slot in slots.transform)
            {
                ExecutionDropHandler dropHandler = slot.GetComponent<ExecutionDropHandler>();
                if (dropHandler)
                {
                    dropHandler.canDrop = true;
                    dropHandler.occupied = false;
                }
            }
        }
    }
}

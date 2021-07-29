using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    WizardMovement wizardmovement;
    [SerializeField]
    private ActionRange actionRange;
    protected override void Execute()
    {
        this.wizardmovement = this.wizard.GetComponent<WizardMovement>();

        if (this.wizardmovement)
        {
            wizardmovement.Walk(actionRange.maxRange.x, actionRange.velocity.x);
        }
        else
        {
            EndExecution();
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (this.isExecuting)
        {
            if (!(this.wizardmovement.isWalking))
            {
                isExecuting = false;
                EndExecution();
            }
        }
    }
}

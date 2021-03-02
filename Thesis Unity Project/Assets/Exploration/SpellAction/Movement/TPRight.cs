using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPRight : Action
{
    // Start is called before the first frame update
    WizardMovement wizardmovement;

    protected override void Execute()
    {
        this.wizardmovement = this.wizard.GetComponent<WizardMovement>();

        if (this.wizardmovement)
        {
            isExecuting = true;
            Vector2 destTile = this.wizard.transform.position;
            destTile.x += 50.0f;
            this.wizardmovement.WalkToDestinationTile(destTile);
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
            if (!(this.wizardmovement.shouldWalk))
            {
                isExecuting = false;
                EndExecution();
            }
        }
    }
}
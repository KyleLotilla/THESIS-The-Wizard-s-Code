using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPRight : Action
{
    bool isRunning;
    WizardMovement wizardmovement;

    public override void Execute()
    {
        this.wizardmovement = this.Wizard.GetComponent<WizardMovement>();

        if (this.wizardmovement)
        {
            this.enabled = true;
            this.isRunning = true; 
            Vector2 destTile = this.Wizard.transform.position;
            destTile.x += 50.0f;
            this.wizardmovement.WalkToDestinationTile(destTile);
        }
    }

    public override bool isFinishedExecuting()
    {
        return !this.isRunning;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isRunning)
        {
            if (!(this.wizardmovement.shouldWalk))
            {
                this.isRunning = false;
                this.enabled = false;
            }
        }
    }
}

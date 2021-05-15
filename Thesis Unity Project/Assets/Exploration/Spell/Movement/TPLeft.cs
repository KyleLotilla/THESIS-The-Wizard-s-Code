using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPLeft : Action
{
    // Start is called before the first frame update
    WizardMovement wizardmovement;

    protected override void Execute()
    {
        this.wizardmovement = this.wizard.GetComponent<WizardMovement>();

        if (this.wizardmovement)
        {
            this.wizardmovement.Walk(-3.0f);
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

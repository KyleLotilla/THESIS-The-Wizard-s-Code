using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPRight : Action
{
    // Start is called before the first frame update
    WizardMovement wizardmovement;
    [SerializeField]
    private ActionRange actionRange;
    protected override void Execute()
    {
        this.wizardmovement = this.wizard.GetComponent<WizardMovement>();

        if (this.wizardmovement)
        {
            //this.wizardmovement.Walk(3.0f);
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
        if (isExecuting)
        {
            if (!(wizardmovement.isWalking))
            {
                isExecuting = false;
                EndExecution();
            }
        }
    }
}
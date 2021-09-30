using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Wizard;
using DLSU.WizardCode.Util;

namespace DLSU.WizardCode.Actions
{
    public class WalkAction : Action
    {
        [SerializeField]
        private GameObjectVariable wizard;
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private ActionVelocity actionVelocity;
        private WizardWalking wizardWalking;

        protected override bool StartExecution()
        {
            Debug.Assert(wizard.Value != null, name + ": No GameObject found for the Wizard GameObject Variable");
            wizardWalking = wizard.Value.GetComponent<WizardWalking>();
            if (wizardWalking != null)
            {
                wizardWalking.Walk(actionRange.MaxRange.x, actionVelocity.Velocity.x);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

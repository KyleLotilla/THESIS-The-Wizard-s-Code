using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Physics;

namespace DLSU.WizardCode.Actions
{
    public class MoveAction : Action
    {
        [SerializeField]
        private GameObjectVariable wizard;
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private ActionVelocity actionVelocity;
        private LimitedDistanceHorizontalMovement wizardlimitedDistanceMovement;

        protected override bool StartExecution()
        {
            Debug.Assert(wizard.Value != null, name + ": No GameObject found for the Wizard GameObject Variable");
            wizardlimitedDistanceMovement = wizard.Value.GetComponent<LimitedDistanceHorizontalMovement>();
            if (wizardlimitedDistanceMovement != null)
            {
                wizardlimitedDistanceMovement.Move(actionRange.MaxRange.x, actionVelocity.Velocity.x);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Actions.Stack;
using DLSU.WizardCode.Actions;

namespace DLSU.WizardCode.Tutorial.ExplorationTutorial1
{
    public class SpawnRandomSpellActionInActionStack : MonoBehaviour
    {
        [SerializeField]
        private ActionStack actionStack;

        public void SpawnRandomSpellAction()
        {
            actionStack.SpawnRandomAction(ActionType.SPELL);
        }
    }

}

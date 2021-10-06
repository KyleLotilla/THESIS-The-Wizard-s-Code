using DLSU.WizardCode.ScriptableObjectVariables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class SetActionFromActionHolderAsCurrentHoveredActionObject : MonoBehaviour
    {
        [SerializeField]
        private ActionHolder actionHolder;
        [SerializeField]
        private GameObjectVariable currentHoveredActionObject;

        public void OnHoverEnter()
        {
            if (actionHolder.Action != null)
            {
                currentHoveredActionObject.Value = actionHolder.Action.gameObject;
            }
            else
            {
                currentHoveredActionObject.Value = null;
            }
        }

        public void OnHoverExited()
        {
            currentHoveredActionObject.Value = null;
        }

    }

}

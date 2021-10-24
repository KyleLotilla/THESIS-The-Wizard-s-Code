using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.UI.Hover
{
    public class SetGameObjectAsCurrentHoveredGameObjectVariable : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable currentHoveredObject;

        public void OnHoverEnter()
        {
            currentHoveredObject.Value = gameObject;
        }

        public void OnHoverExited()
        {
            currentHoveredObject.Value = null;
        }
    }

}

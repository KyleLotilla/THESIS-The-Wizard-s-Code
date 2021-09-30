using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLSU.WizardCode.UI.DragNDrop;

namespace DLSU.WizardCode.Actions
{
    public class ActionHolder : MonoBehaviour
    {
        [SerializeField]
        private Action action;
        public Action Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
    }

}

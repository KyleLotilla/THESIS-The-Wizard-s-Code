using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Actions.UI
{
    public class ShowActionRangeOfCurrentHoveredActionObject : MonoBehaviour
    {
        [SerializeField]
        private ActionRangeLineRenderer actionRangeLineRenderer;
        [SerializeField]
        private GameObjectVariable currentHoveredActionObject;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnActionObjectHoverEnter()
        {
            if (currentHoveredActionObject.Value != null)
            {
                ActionRange actionRangeOfCurrentHoveredActionObject = currentHoveredActionObject.Value.GetComponent<ActionRange>();
                if (actionRangeOfCurrentHoveredActionObject != null)
                {
                    ActionVelocity actionVelocityOfCurrentHoveredActionObject = currentHoveredActionObject.Value.GetComponent<ActionVelocity>();
                    if (actionVelocityOfCurrentHoveredActionObject != null)
                    {
                        actionRangeLineRenderer.ShowRange(actionRangeOfCurrentHoveredActionObject, actionVelocityOfCurrentHoveredActionObject);
                    }
                    else
                    {
                        actionRangeLineRenderer.ShowRange(actionRangeOfCurrentHoveredActionObject);
                    }
                }
            }
        }
    }

}

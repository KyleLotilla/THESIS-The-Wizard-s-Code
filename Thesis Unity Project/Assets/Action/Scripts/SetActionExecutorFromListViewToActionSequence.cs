using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class SetActionExecutorFromListViewToActionSequence : MonoBehaviour
    {
        [SerializeField]
        private ActionSequence actionSequence;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnItemViewWithDataCreated(GameObject itemView, object item)
        {
            CopyActionExecutorToSequence(itemView);
        }

        public void OnItemViewWithNoDataCreated(GameObject itemView)
        {
            CopyActionExecutorToSequence(itemView);
        }

        private void CopyActionExecutorToSequence(GameObject itemView)
        {
            ActionExecutor actionExecutor = itemView.GetComponent<ActionExecutor>();
            if (actionExecutor != null)
            {
                actionSequence.AddActionExecutor(actionExecutor);
            }
        }

        public void OnListViewClear()
        {
            actionSequence.ClearActionExecutors();
        }
    }

}

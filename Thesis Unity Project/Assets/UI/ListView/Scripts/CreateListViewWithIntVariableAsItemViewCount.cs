using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.ListViews;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.UI.ListViews
{
    public class CreateListViewWithIntVariableAsItemViewCount : MonoBehaviour
    {
        [SerializeField]
        private IntVariable itemViewCount;
        [SerializeField]
        private ListView listView;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(itemViewCount.Value >= 0, name + ": Item View Count must be greater or equal to 0");
            if (itemViewCount.Value >= 0)
            {
                listView.CreateList(itemViewCount.Value);
            }
        }
    }

}

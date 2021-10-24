using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Views
{
    public class ListItemView : MonoBehaviour
    {
        [SerializeField]
        private UnityEventOneNativeObjectParam onItemViewWithDataCreated;

        public void RaiseOnItemViewWithDataCreated(object data)
        {
            onItemViewWithDataCreated?.Invoke(data);
        }
    }

}


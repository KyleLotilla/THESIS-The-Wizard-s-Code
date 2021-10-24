using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Tags;

namespace DLSU.WizardCode.UI.Tabs
{
    public class Tab : MonoBehaviour
    {
        [SerializeField]
        private Tag tabTag;
        public Tag TabTag
        {
            get
            {
                return tabTag;
            }
        }
        [SerializeField]
        private UnityEvent onSwitchedTo;
        [SerializeField]
        private UnityEvent onSwitchedOut;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SwitchToTab()
        {
            gameObject.SetActive(true);
            onSwitchedTo?.Invoke();
        }

        public void SwitchOutTab()
        {
            onSwitchedOut?.Invoke();
            gameObject.SetActive(false);
        }
    }

}

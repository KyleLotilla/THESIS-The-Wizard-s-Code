using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Tabs
{

    public class DisplayTabs : MonoBehaviour
    {
        [SerializeField]
        private List<Tab> tabs;
        [SerializeField]
        private Tag tagOfCurrentTab;
        [SerializeField]
        private UnityEvent onTabSwitch;
        [SerializeField]
        private UnityEvent onNoTabSwitch;

        private Dictionary<Tag, Tab> tagTabMap;

        private void Awake()
        {
            tagTabMap = new Dictionary<Tag, Tab>();
            foreach (Tab tab in tabs)
            {
                tagTabMap[tab.TabTag] = tab;
            }
        }

        private void Start()
        {
            if (tagOfCurrentTab != null)
            {
                tagTabMap[tagOfCurrentTab].SwitchToTab();
                onTabSwitch?.Invoke();
            }
        }

        public void SwitchTab(Tag tag)
        {
            if (tag != tagOfCurrentTab)
            {
                HideCurrentTab();
                if (tag != null)
                {
                    if (tagTabMap.ContainsKey(tag))
                    {
                        tagOfCurrentTab = tag;
                        tagTabMap[tag].SwitchToTab();
                        onTabSwitch?.Invoke();
                    }
                    else
                    {
                        tagOfCurrentTab = null;
                        onNoTabSwitch?.Invoke();
                    }
                }
                else
                {
                    tagOfCurrentTab = null;
                    onNoTabSwitch?.Invoke();
                }
            }
        }

        public void SwitchToNoTab()
        {
            SwitchTab(null);
        }

        private void HideCurrentTab()
        {
            if (tagOfCurrentTab != null)
            {
                tagTabMap[tagOfCurrentTab].SwitchOutTab();
                tagOfCurrentTab = null;
            }
        }
    }

}

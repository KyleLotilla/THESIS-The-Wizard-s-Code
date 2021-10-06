using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.Tabs
{

    public class TabsPanel : MonoBehaviour
    {
        [SerializeField]
        private List<TagTabPair> initialTabs;
        [SerializeField]
        private Tag tagOfCurrentTab;
        [SerializeField]
        private UnityEventOneTagOneGameObjectParam onTabSwitch;
        [SerializeField]
        private UnityEvent onNoTabSwitch;

        private Dictionary<Tag, GameObject> tabs;

        private void Awake()
        {
            tabs = new Dictionary<Tag, GameObject>();
            foreach (TagTabPair tagTabPair in initialTabs)
            {
                tabs[tagTabPair.tag] = tagTabPair.tab;
            }
        }

        public void SwitchTab(Tag tag)
        {
            HideCurrentTab();
            if (tabs.ContainsKey(tag))
            {
                tabs[tag].SetActive(true);
                tagOfCurrentTab = tag;
                onTabSwitch?.Invoke(tag, tabs[tag]);
            }
            else
            {
                tagOfCurrentTab = null;
                onNoTabSwitch?.Invoke();
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
                tabs[tagOfCurrentTab].SetActive(false);
                tagOfCurrentTab = null;
            }
        }

        [Serializable]
        private class TagTabPair
        {
            public Tag tag;
            public GameObject tab;
        }
    }

}

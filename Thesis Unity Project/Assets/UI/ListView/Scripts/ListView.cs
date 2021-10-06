using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.ListViews
{
    public class ListView : MonoBehaviour
    {
        [SerializeField]
        private GameObject itemViewPrefab;
        [SerializeField]
        private UnityEventOneGameObjectOneNativeObjectParam onItemViewWithDataCreated;
        [SerializeField]
        private UnityEventOneGameObjectParam onItemViewWithNoDataCreated;
        [SerializeField]
        private UnityEvent onListViewClear;

        private int itemViewCount = 0;
        private List<object> dataModel;
        private List<GameObject> itemViews;

        public IEnumerable<GameObject> ItemViews
        {
            get
            {
                return itemViews;
            }
        }

        private void Awake()
        {
            itemViews = new List<GameObject>();
        }

        public void CreateList(int itemViewCount)
        {
            CreateList(null, itemViewCount);
        }

        public void CreateList(List<object> dataModel)
        {
            CreateList(dataModel, dataModel.Count);
        }

        public void CreateList(List<object> dataModel, int itemViewCount)
        {
            this.dataModel = dataModel;
            this.itemViewCount = itemViewCount;
            RefreshList();
        }

        public void RefreshList()
        {
            Clear();
            int numberOfItemViewsCreated = 0;
            if (dataModel != null)
            {
                foreach (object item in dataModel)
                {
                    GameObject itemView = Instantiate(itemViewPrefab, transform);
                    Debug.Assert(itemView != null, name + ": Item View not instantiated");
                    if (itemView != null)
                    {
                        onItemViewWithDataCreated?.Invoke(itemView, item);
                        numberOfItemViewsCreated++;
                        itemViews.Add(itemView);
                    }
                }
            }

            if (numberOfItemViewsCreated < itemViewCount)
            {
                for (; numberOfItemViewsCreated < itemViewCount; numberOfItemViewsCreated++)
                {
                    GameObject itemView = Instantiate(itemViewPrefab, transform);
                    Debug.Assert(itemView != null, name + ": Item View not instantiated");
                    if (itemView != null)
                    {
                        onItemViewWithNoDataCreated?.Invoke(itemView);
                        itemViews.Add(itemView);
                    }
                }
            }
        }


        public void Clear()
        {
            foreach (GameObject itemView in itemViews)
            {
                Destroy(itemView);
            }
            itemViews.Clear();
            onListViewClear?.Invoke();
        }
    }
}


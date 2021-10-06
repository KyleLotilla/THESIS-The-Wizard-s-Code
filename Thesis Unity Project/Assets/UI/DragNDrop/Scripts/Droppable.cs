using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.DragNDrop
{
    public class Droppable : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private bool isDroppable = true;
        public bool IsDroppable
        {
            get
            {
                return isDroppable;
            }
            set
            {
                isDroppable = value;
            }
        }

        [SerializeField]
        private UnityEventOnePointerEventDataParam onDrop;


        public void OnDrop(PointerEventData eventData)
        {
            if (IsDroppable)
            {
                onDrop?.Invoke(eventData);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

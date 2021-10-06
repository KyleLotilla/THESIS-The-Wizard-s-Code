using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.DragNDrop
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private bool isDraggable = true;
        public bool IsDraggable
        {
            get
            {
                return isDraggable;
            }
            set
            {
                isDraggable = value;
            }
        }
        [SerializeField]
        private UnityEventOnePointerEventDataParam onBeginDrag;
        [SerializeField]
        private UnityEventOnePointerEventDataParam onDrag;
        [SerializeField]
        private UnityEventOnePointerEventDataParam onEndDrag;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (IsDraggable)
            {
                onBeginDrag?.Invoke(eventData);
            }
            else
            {
                eventData.pointerDrag = null;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            onDrag?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            onEndDrag?.Invoke(eventData);
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DLSU.WizardCode.UI.DragNDrop;

namespace DLSU.WizardCode.UI.Slots
{
    public class DraggableSlotSpace : MonoBehaviour
    {
        [SerializeField]
        private SlotSpace slotSpace;
        [SerializeField]
        private LayoutGroup layoutGroup;

        private Vector3 dragStartPos;
        private CanvasGroup slotCanvasGroup;
        private Canvas slotCanvas;
        private bool isDragging = false;

        public void OnSlotAdded(GameObject slot)
        {
            SwitchToSlot(slot);
        }

        public void OnSlotSwapped(GameObject oldSlot, GameObject slot)
        {
            OnEndDrag(null);
            SwitchToSlot(slot);
        }

        private void SwitchToSlot(GameObject slot)
        {
            CanvasGroup canvasGroup = slot.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                slotCanvasGroup = canvasGroup;
            }
            Canvas canvas = slot.GetComponent<Canvas>();
            if (canvas != null)
            {
                slotCanvas = canvas;
            }
        }

        public void OnSlotRemoved(GameObject removedSlot)
        {
            OnEndDrag(null);
            slotCanvasGroup = null;
            slotCanvas = null;
        }

        void Update()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!slotSpace.IsEmpty)
            {
                isDragging = true;
                slotCanvas.overrideSorting = true;
                slotCanvas.sortingOrder = 1;
                slotCanvasGroup.blocksRaycasts = false;
                layoutGroup.enabled = false;
                dragStartPos = slotSpace.Slot.transform.position;
            }
            else
            {
                eventData.pointerDrag = null;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!slotSpace.IsEmpty)
            {
                slotSpace.Slot.transform.position = Input.mousePosition;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (isDragging)
            {
                slotCanvas.overrideSorting = false;
                slotCanvasGroup.blocksRaycasts = true;
                layoutGroup.enabled = true;
                isDragging = false;
                if (!slotSpace.IsEmpty)
                {
                    slotSpace.Slot.transform.position = dragStartPos;
                }
            }
        }
    }

}

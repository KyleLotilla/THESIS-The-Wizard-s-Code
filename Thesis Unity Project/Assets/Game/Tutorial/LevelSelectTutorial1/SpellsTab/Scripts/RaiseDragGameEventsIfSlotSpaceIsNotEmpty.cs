using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using UnityEngine.EventSystems;
using DLSU.WizardCode.UI.Slots;

namespace DLSU.WizardCode.Tutorial.LevelSelectTutorial1.SpellsTab
{
    public class RaiseDragGameEventsIfSlotSpaceIsNotEmpty : MonoBehaviour
    {
        [SerializeField]
        private GameEvent onDragStart;
        [SerializeField]
        private GameEvent onDragEnd;
        [SerializeField]
        private SlotSpace slotSpace;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!slotSpace.IsEmpty)
            {
                onDragStart.Raise();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!slotSpace.IsEmpty)
            {
                onDragEnd.Raise();
            }
        }
    }
}


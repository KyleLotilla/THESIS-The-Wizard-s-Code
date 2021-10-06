using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DLSU.WizardCode.UI.Hover
{
    public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private bool isHoverable = true;
        public bool IsHoverable
        {
            get
            {
                return isHoverable;
            }
            set
            {
                isHoverable = value;
            }
        }
        [SerializeField]
        private UnityEvent onHoverEnter;
        [SerializeField]
        private UnityEvent onHoverExit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (isHoverable)
            {
                onHoverEnter?.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isHoverable)
            {
                onHoverExit?.Invoke();
            }
        }
    }

}

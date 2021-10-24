using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace DLSU.WizardCode.UI.Views
{
    public class IconView : MonoBehaviour
    {
        [SerializeField]
        private Image icon;
        public Image Icon
        {
            get
            {
                return icon;
            }
        }
        [SerializeField]
        private bool interactable = true;
        public bool Interactable
        {
            get
            {
                return interactable;
            }
            set
            {
                if (value)
                {
                    SetInteractable();
                }
                else
                {
                    SetNonInteractable();
                }
            }
        }
        [SerializeField]
        private Color interactableIconColor = Color.white;
        [SerializeField]
        private Color nonInteractableIconColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        [SerializeField]
        private UnityEvent onIconInteractable;
        [SerializeField]
        private UnityEvent onIconNonInteractable;

        // Start is called before the first frame update
        void Start()
        {
            if (!interactable)
            {
                SetNonInteractable();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SetInteractable()
        {
            interactable = true;
            icon.color = interactableIconColor;
            onIconInteractable?.Invoke();
        }

        private void SetNonInteractable()
        {
            interactable = false;
            icon.color = nonInteractableIconColor;
            onIconNonInteractable?.Invoke();
        }
    }

}

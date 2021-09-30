using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.UI.Slots
{
    public class IconSlotDraggableGhost : MonoBehaviour
    {
        [SerializeField]
        private IconSlot iconSlot;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void OnGhostCreated(GameObject ghost)
        {
            IconSlot ghostIconSlot = ghost.GetComponent<IconSlot>();
            if (ghostIconSlot != null)
            {
                ghostIconSlot.Icon.sprite = iconSlot.Icon.sprite;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

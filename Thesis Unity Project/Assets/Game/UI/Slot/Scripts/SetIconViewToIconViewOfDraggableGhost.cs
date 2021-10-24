using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class SetIconViewToIconViewOfDraggableGhost : MonoBehaviour
    {
        [SerializeField]
        private IconView iconView;

        public void OnGhostCreated(GameObject ghost)
        {
            IconView ghostIconView = ghost.GetComponent<IconView>();
            if (ghostIconView != null)
            {
                ghostIconView.Icon.sprite = iconView.Icon.sprite;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;

namespace DLSU.WizardCode.UI.Slots
{
    public class IconViewDraggableGhost : MonoBehaviour
    {
        [SerializeField]
        private IconView iconView;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void OnGhostCreated(GameObject ghost)
        {
            IconView ghostIconView = ghost.GetComponent<IconView>();
            if (ghostIconView != null)
            {
                ghostIconView.Icon.sprite = iconView.Icon.sprite;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

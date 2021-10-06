using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.UI.DragNDrop
{
    public class DraggableGhost : MonoBehaviour
    {
        [SerializeField]
        private GameObject ghostPrefab;
        [SerializeField]
        private UnityEventOneGameObjectParam onGhostCreated;
        private GameObject currentGhost;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            currentGhost = Instantiate(ghostPrefab, Input.mousePosition, Quaternion.identity, this.transform.parent);
            if (currentGhost != null)
            {
                onGhostCreated?.Invoke(currentGhost);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            currentGhost.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DestroyImmediate(currentGhost);
        }
    }

}

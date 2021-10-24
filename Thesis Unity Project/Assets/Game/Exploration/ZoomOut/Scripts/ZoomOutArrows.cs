using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Exploration.ZoomOut
{
    public class ZoomOutArrows : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable mainCamera;
        [SerializeField]
        private GameObjectVariable bottomLeftBoundary;
        [SerializeField]
        private GameObjectVariable topRightBoundary;
        [SerializeField]
        private GameObject upArrow;
        [SerializeField]
        private GameObject downArrow;
        [SerializeField]
        private GameObject leftArrow;
        [SerializeField]
        private GameObject rightArrow;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void OnZoomOutMove()
        {
            Vector3 cameraPosition = mainCamera.Value.transform.position;
            Vector3 bottomLeftBoundaryPosition = bottomLeftBoundary.Value.transform.position;
            Vector3 topRightBoundaryPosition = topRightBoundary.Value.transform.position;

            if (cameraPosition.x <= bottomLeftBoundaryPosition.x)
            {
                leftArrow.SetActive(false);
            }
            else
            {
                leftArrow.SetActive(true);
            }

            if (cameraPosition.x >= topRightBoundaryPosition.x)
            {
                rightArrow.SetActive(false);
            }
            else
            {
                rightArrow.SetActive(true);
            }

            if (cameraPosition.y <= bottomLeftBoundaryPosition.y)
            {
                downArrow.SetActive(false);
            }
            else
            {
                downArrow.SetActive(true);
            }

            if (cameraPosition.y >= topRightBoundaryPosition.y)
            {
                upArrow.SetActive(false);
            }
            else
            {
                upArrow.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


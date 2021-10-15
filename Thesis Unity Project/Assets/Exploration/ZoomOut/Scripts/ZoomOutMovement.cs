using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Exploration.ZoomOut
{
    public class ZoomOutMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable mainCamera;
        [SerializeField]
        private GameObjectVariable bottomLeftBoundary;
        [SerializeField]
        private GameObjectVariable topRightBoundary;
        [SerializeField]
        private Vector2 sensitivity;
        [SerializeField]
        private UnityEvent onZoomOutMove;

        private Vector2 previousMousePosition;
        private bool isMouseHeld = false;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (isMouseHeld)
                {
                    Vector2 currentMousePosition = Input.mousePosition;
                    Vector2 delta = previousMousePosition - currentMousePosition;
                    Vector3 cameraPosition = mainCamera.Value.transform.position;
                    Vector3 bottomLeftBoundaryPosition = bottomLeftBoundary.Value.transform.position;
                    Vector3 topRightBoundaryPosition = topRightBoundary.Value.transform.position;
                    cameraPosition += (Vector3)(delta * sensitivity);

                    if (cameraPosition.x < bottomLeftBoundaryPosition.x)
                    {
                        cameraPosition.x = bottomLeftBoundaryPosition.x;
                    }
                    else if (cameraPosition.x > topRightBoundaryPosition.x)
                    {
                        cameraPosition.x = topRightBoundaryPosition.x;
                    }

                    if (cameraPosition.y < bottomLeftBoundaryPosition.y)
                    {
                        cameraPosition.y = bottomLeftBoundaryPosition.y;
                    }
                    else if (cameraPosition.y > topRightBoundaryPosition.y)
                    {
                        cameraPosition.y = topRightBoundaryPosition.y;
                    }

                    mainCamera.Value.transform.position = cameraPosition;
                    previousMousePosition = currentMousePosition;
                    onZoomOutMove?.Invoke();
                }
                else
                {
                    isMouseHeld = true;
                    previousMousePosition = Input.mousePosition;
                }

            }
            else
            {
                isMouseHeld = false;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutMovement : MonoBehaviour
{
    private Vector2 previousMousePosition;
    private bool isMouseHeld = false;
    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField]
    private Transform bottomLeftBoundary;
    [SerializeField]
    private Transform topRightBoundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isMouseHeld)
            {
                Vector2 currentMousePosition = Input.mousePosition;
                Vector2 delta = previousMousePosition - currentMousePosition;
                Vector3 cameraPosition = this.transform.position;
                cameraPosition += (Vector3) (delta * sensitivity);
                
                if (cameraPosition.x < bottomLeftBoundary.position.x)
                {
                    cameraPosition.x = bottomLeftBoundary.position.x;
                }
                else if (cameraPosition.x > topRightBoundary.position.x)
                {
                    cameraPosition.x = topRightBoundary.position.x;
                }

                if (cameraPosition.y < bottomLeftBoundary.position.y)
                {
                    cameraPosition.y = bottomLeftBoundary.position.y;
                }
                else if (cameraPosition.y > topRightBoundary.position.y)
                {
                    cameraPosition.y = topRightBoundary.position.y;
                }
                
                this.transform.position = cameraPosition;

                previousMousePosition = currentMousePosition;
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

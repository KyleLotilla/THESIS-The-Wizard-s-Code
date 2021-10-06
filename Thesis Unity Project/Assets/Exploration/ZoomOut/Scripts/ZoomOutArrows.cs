using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutArrows : MonoBehaviour
{
    [SerializeField]
    private GameObject upArrow;
    [SerializeField]
    private GameObject downArrow;
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;
    [SerializeField]
    private ZoomOutMovement zoomOutMovement;


    // Start is called before the first frame update
    void Start()
    {
        zoomOutMovement.OnZoomOutMove += OnZoomOutMove;
    }

    private void OnZoomOutMove(Vector2 bottomLeftBoundary, Vector2 topRightBoundary, Vector2 currentPosition)
    {
        if (currentPosition.x <= bottomLeftBoundary.x)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
        }

        if (currentPosition.x >= topRightBoundary.x)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }

        if (currentPosition.y <= bottomLeftBoundary.y)
        {
            downArrow.SetActive(false);
        }
        else
        {
            downArrow.SetActive(true);
        }

        if (currentPosition.y >= topRightBoundary.y)
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

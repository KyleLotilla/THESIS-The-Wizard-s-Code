using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Util;

public class CameraZoomHandler : MonoBehaviour
{
    [SerializeField]
    private ExplorationZoom explorationZoom;
    [SerializeField]
    private CameraFollow cameraFollow;
    [SerializeField]
    private ZoomOutMovement zoomOutMovement;

    // Start is called before the first frame update
    void Start()
    {
        explorationZoom.OnZoomIn += OnZoomIn;
        explorationZoom.OnZoomOut += OnZoomOut;
    }

    private void OnZoomOut()
    {
        cameraFollow.enabled = false;
        zoomOutMovement.enabled = true;
    }

    private void OnZoomIn()
    {
        cameraFollow.enabled = true;
        zoomOutMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

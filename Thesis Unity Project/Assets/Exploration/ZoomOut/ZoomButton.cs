using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomButton : MonoBehaviour
{
    [SerializeField]
    private ExplorationZoom explorationZoom;
    [SerializeField]
    private bool isZoomOut = false;
    [SerializeField]
    private Text text; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressed()
    {
        if (!isZoomOut)
        {
            explorationZoom.ZoomOut();
            text.text = "Back";
            isZoomOut = true;
        }
        else
        {
            explorationZoom.ZoomIn();
            text.text = "Zoom Out";
            isZoomOut = false;
        }
    }
}

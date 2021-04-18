using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnZoomOut();
public delegate void OnZoomIn();

public class ExplorationZoom : MonoBehaviour
{
    public event OnZoomOut OnZoomOut;
    public event OnZoomIn OnZoomIn;

    [SerializeField]
    private TabsPanel explorationTabsPanel;
    [SerializeField]
    private int zoomOutPage;
    [SerializeField]
    private int gamePanelPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomIn()
    {
        OnZoomIn?.Invoke();
        explorationTabsPanel.SwitchPage(gamePanelPage);
    }

    public void ZoomOut()
    {
        OnZoomOut?.Invoke();
        explorationTabsPanel.SwitchPage(zoomOutPage);
    }


}

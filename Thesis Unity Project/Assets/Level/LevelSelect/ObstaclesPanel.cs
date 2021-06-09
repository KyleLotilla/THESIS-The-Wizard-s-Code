using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPanel : ItemSlotMenu<ObstacleLevelInfo>
{
    [SerializeField]
    private ObstacleDatabase obstacleDatabase;

    public void ShowObstacles(List<ObstacleLevelInfo> obstacleLevelInfos)
    {
        items = obstacleLevelInfos;
        RefreshMenu();
    }

    protected override void OnSlotSpawn(GameObject slot, GameObject space, ObstacleLevelInfo item)
    {
        Obstacle obstacle = obstacleDatabase.GetObstacle(item.obstacleID);
        if (obstacle != null)
        {
            InfoIconPanel infoIconPanel = slot.GetComponent<InfoIconPanel>();
            if (infoIconPanel != null)
            {
                infoIconPanel.icon.sprite = obstacle.icon;
                infoIconPanel.text.text = obstacle.name + " x " + item.numObstacles;
            }
        }
    }

    /*
    private void Awake()
    {   
        if (currentPanels == null)
        {
            currentPanels = new List<GameObject>();
        }
    }

    public void ShowObstacles(List<int> obstacleIDs, List<int> numObstacles)
    {
        Clear();
        for (int i = 0; i < obstacleIDs.Count; i++)
        {
            Obstacle obstacle = obstacleDatabase.GetObstacle(obstacleIDs[i]);
            if (obstacle != null)
            {
                GameObject infoIconPanelObject = Instantiate(infoIconPanelPrefab, this.transform);
                currentPanels.Add(infoIconPanelObject);
                if (infoIconPanelObject != null)
                {
                    InfoIconPanel infoIconPanel = infoIconPanelObject.GetComponent<InfoIconPanel>();
                    if (infoIconPanel != null)
                    {
                        infoIconPanel.icon.sprite = obstacle.icon;
                        infoIconPanel.text.text = obstacle.name + " x " + numObstacles[i];
                    }
                }
            }
        }
    }
    
    public void Clear()
    {
        foreach(GameObject panel in currentPanels)
        {
            DestroyImmediate(panel);
        }
        currentPanels.Clear();
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoUI : MonoBehaviour
{
    [SerializeField]
    private Text levelTitle; 
    [SerializeField]
    private ObstaclesPanel obstaclesPanel;
    [SerializeField]
    private MaterialsPanel materialsPanel;
    [SerializeField]
    private Image levelOverview;
    void Start()
    {
        
    }

    public void ShowLevelInfo(Level level)
    {
        levelTitle.text = "Level " + level.worldNum + "-" + level.levelNum;
        obstaclesPanel.ShowObstacles(level.obstacles, level.numObstacles);
        materialsPanel.ShowMaterials(level.materials, level.numMaterials);
        levelOverview.sprite = level.levelOverview;
    }
}

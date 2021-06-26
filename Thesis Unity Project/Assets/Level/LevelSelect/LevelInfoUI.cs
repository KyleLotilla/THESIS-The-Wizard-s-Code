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
    private SpellsInfoPanel spellsInfoPanel;
    [SerializeField]
    private Image levelOverview;
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private LoadScene loadScene;
    [SerializeField]
    private PlayerLevelProgression playerlevelProgression;
    [SerializeField]
    private FillStar starFill;

    void Start()
    {
        
    }

    public void ShowLevelInfo(Level level)
    {
        levelTitle.text = "Level " + level.worldNum + "-" + level.levelNum;
        obstaclesPanel.ShowObstacles(level.obstacleLevelInfos);
        spellsInfoPanel.ShowSpells(level.unlockableSpellsIDs);
        levelOverview.sprite = level.levelOverview;
        LevelProgression levelProgression = playerlevelProgression.GetLevelProgression(level.levelID);
        if (levelProgression != null)
        {
            starFill.FillUpStar(levelProgression.highScore);
        }
        else
        {
            starFill.FillUpStar(0);
        }
        if (!isTutorial)
        {
            loadScene.index = level.sceneIndex;
        }
    }
}

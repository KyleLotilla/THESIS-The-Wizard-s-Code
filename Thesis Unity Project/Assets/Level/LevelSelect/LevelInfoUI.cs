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
    /*
    [SerializeField]
    private MaterialsPanel materialsPanel;
    */
    [SerializeField]
    private SpellsInfoPanel spellsInfoPanel;
    [SerializeField]
    private Image levelOverview;
    [SerializeField]
    private Text highScore;
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
        //materialsPanel.ShowMaterials(level.materials, level.numMaterials);
        levelOverview.sprite = level.levelOverview;
        //highScore.text = level.levelProgression.highScore.ToString();
        LevelProgression levelProgression = playerlevelProgression.GetLevelProgression(level.levelID);
        if (levelProgression != null)
        {
            //highScore.text = levelProgression.highScore.ToString();
            starFill.FillUpStar(levelProgression.highScore, level.maximumScore);
        }
        else
        {
            //highScore.text = "0";
            starFill.FillUpStar(0, level.maximumScore);
        }
        loadScene.index = level.sceneIndex;
    }
}

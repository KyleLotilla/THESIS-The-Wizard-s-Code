using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoUI : MonoBehaviour
{
    [SerializeField]
    private Text levelTitle;
    /*
    [SerializeField]
    private ObstaclesPanel obstaclesPanel;
    [SerializeField]
    private SpellsInfoPanel spellsInfoPanel;
    */
    [SerializeField]
    private Image levelOverview;
    [SerializeField]
    private bool isTutorial = false;
    /*
    [SerializeField]
    private LevelProgressionDatabase playerlevelProgression;
    [SerializeField]
    private FillUpStarScoring starFill;
    /*
    [SerializeField]
    private StarRequirement starRequirement;
    */
    void Start()
    {
        
    }

    /*
    public void ShowLevelInfo(Level level)
    {
        levelTitle.text = "Level " + level.WorldNumber + "-" + level.LevelNumber;
        
        obstaclesPanel.ShowObstacles(level.obstacleLevelInfos);
        spellsInfoPanel.ShowSpells(level.UnlockableSpellsIDs);

        levelOverview.sprite = level.LevelOverview;
        LevelProgression levelProgression = playerlevelProgression.GetLevelProgression(level.LevelID);
        //starRequirement.Stars(level.twoStarRequirement, level.threeStarRequirement);
        if (levelProgression != null)
        {
            starFill.FillUpStar(levelProgression.highScore);
        }
        else
        {
            starFill.FillUpStar(0);
        }
    }
    */
}

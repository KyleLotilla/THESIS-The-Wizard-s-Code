﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Image levelOverviewIcon;
    [SerializeField]
    private GameObject lockIcon;
    [SerializeField]
    private Button button;
    /*
    [SerializeField]
    private LevelProgressionDatabase playerLevelProgression;
    */
    [SerializeField]
    private Text minimumReq;
    /*
    [SerializeField]
    private FillUpStarScoring fillStar;
    */
    /*
    private Level _level;
    public Level level
    {
        private get
        {
            return _level;
        }
        set
        {
            _level = value;
            text.text = _level.WorldNumber + "-" + _level.LevelNumber;
            levelOverviewIcon.sprite = _level.LevelOverview;
            LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(_level.LevelID);
            if (levelProgression != null)
            {
                fillStar.FillUpStar(levelProgression.highScore);
            }
            else
            {
                fillStar.FillUpStar(0);
            }
        }
    }
    */
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
        //OnLevelSelected?.Invoke(level);
    }
    
    public void LockLevel()
    {
        Color iconColor = levelOverviewIcon.color;
        iconColor.a = 50;
        levelOverviewIcon.color = iconColor;
        //lockIcon.SetActive(true);
        //minimumReq.SetActive(true);
        //minimumReq.text = "Stars Required:" + _level.starUnlockRequirement;
        button.interactable = false;
    }

    public void LockForTutorial()
    {
        Color iconColor = levelOverviewIcon.color;
        iconColor.a = 50;
        levelOverviewIcon.color = iconColor;
        button.interactable = false;
    }

    public void UnlockForTutorial()
    {
        Color iconColor = levelOverviewIcon.color;
        iconColor.a = 255;
        levelOverviewIcon.color = iconColor;
        button.interactable = true;
    }
}
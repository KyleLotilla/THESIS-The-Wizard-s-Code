using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : ItemSlotMenu<Level>
{
    [SerializeField]
    private GameObject levelSelectUI;
    [SerializeField]
    private LevelUI levelUI;
    [SerializeField]
    private GameObject levelSelectButtonPrefab;
    [SerializeField]
    private LevelDatabase levelDatabase;
    [SerializeField]
    private PlayerLevelProgression playerLevelProgression;
    [SerializeField]
    private TabsPanel tabsPanel;
    [SerializeField]
    private int levelUIPage;
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private int nextTutorialLevel = 1;
    [SerializeField]
    private int totalStars = 0;
    void Start()
    {
        /*
        foreach (Level level in levelDatabase)
        {
            GameObject levelSelectButtonObject = Instantiate(levelSelectButtonPrefab, this.transform);
            if (levelSelectButtonObject != null)
            {
                LevelSelectButton levelSelectButton = levelSelectButtonObject.GetComponent<LevelSelectButton>();
                if (levelSelectButton != null)
                {
                    levelSelectButton.level = level;
                    levelSelectButton.OnLevelSelected += OnLevelSelected;
                    if (isTutorial && level.levelID != nextTutorialLevel)
                    {
                        levelSelectButton.LockForTutorial();
                    }
                }
            }
        }
        */
        CalculateTotalStars();
        items = levelDatabase;
        RefreshMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnSlotSpawn(GameObject slot, GameObject space, Level item)
    {
        LevelSelectButton levelSelectButton = slot.GetComponent<LevelSelectButton>();
        if (levelSelectButton != null)
        {
            levelSelectButton.level = item;
            levelSelectButton.OnLevelSelected += OnLevelSelected;
            if (isTutorial && item.levelID != nextTutorialLevel)
            {
                levelSelectButton.LockForTutorial();
            }
            else if (totalStars < item.starRequirement)
            {
                levelSelectButton.LockLevel();
            }
        }
    }

    void OnLevelSelected(Level level)
    {
        levelUI.ShowLevelUI(level);
        tabsPanel.SwitchPage(levelUIPage);
    }

    private void CalculateTotalStars()
    {
        totalStars = 0;
        foreach (LevelProgression levelProgression in playerLevelProgression)
        {
            Level level = levelDatabase.GetLevel(levelProgression.levelID);
            if (level != null)
            {
                totalStars += (int) (Mathf.Lerp(0, 3, (float) levelProgression.highScore / (float) level.maximumScore));
            }
        }
    }
}

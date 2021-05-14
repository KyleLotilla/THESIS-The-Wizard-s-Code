using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
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
    private TabsPanel tabsPanel;
    [SerializeField]
    private int levelUIPage;
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private int nextTutorialLevel = 1;
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnLevelSelected(Level level)
    {
        levelUI.ShowLevelUI(level);
        tabsPanel.SwitchPage(levelUIPage);
    }
}

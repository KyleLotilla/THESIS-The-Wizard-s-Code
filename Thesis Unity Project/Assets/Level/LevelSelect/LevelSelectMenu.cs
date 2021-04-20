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
        levelSelectUI.SetActive(false);
        levelUI.ShowLevelUI(level);
    }
}

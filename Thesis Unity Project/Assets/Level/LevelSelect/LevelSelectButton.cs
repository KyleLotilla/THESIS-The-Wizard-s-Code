using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnLevelSelected(Level level);

public class LevelSelectButton : MonoBehaviour
{
    public event OnLevelSelected OnLevelSelected;

    [SerializeField]
    private Text text;
    [SerializeField]
    private Image levelOverviewIcon;
    [SerializeField]
    private GameObject lockIcon;
    [SerializeField]
    private Button button;

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
            text.text = _level.worldNum + "-" + _level.levelNum;
            levelOverviewIcon.sprite = _level.levelOverview;
            if (!_level.levelProgression.isUnlocked)
            {
                Color iconColor = levelOverviewIcon.color;
                iconColor.a = 50;
                levelOverviewIcon.color = iconColor;
                lockIcon.SetActive(true);
                button.interactable = false;
            }
        }
    }
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
        OnLevelSelected?.Invoke(level);
    }

    public void LockForTutorial()
    {
        Color iconColor = levelOverviewIcon.color;
        iconColor.a = 50;
        levelOverviewIcon.color = iconColor;
        button.interactable = false;
    }
}

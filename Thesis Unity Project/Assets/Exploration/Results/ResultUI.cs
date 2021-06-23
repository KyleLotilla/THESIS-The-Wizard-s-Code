using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private int levelID;
    [SerializeField]
    private PlayerLevelProgression playerLevelProgression;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject optionsPanel;
    [SerializeField]
    private ExplorationScore explorationScore;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private GameObject newHighScoreText;

    [SerializeField]
    private SpellsInfoPanel spellsInfoPanel;

    private int oldHighScore = 0;

    [SerializeField]
    private FillStar ScoreFillStar;

    [SerializeField]
    private FillStar HighScoreFillStar;

    [SerializeField]
    private int TotalScore;


    // Start is called before the first frame update
    void Start()
    {
        LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(levelID);
        if (levelProgression != null)
        {
            oldHighScore = levelProgression.highScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowResults(List<int> unlockedSpellsIDs)
    {

        if (unlockedSpellsIDs != null)
        {
            spellsInfoPanel.ShowSpells(unlockedSpellsIDs);
        }

        int score = explorationScore.currentScore;
        scoreText.text = score.ToString();
        ScoreFillStar.FillUpStar(score, TotalScore);
        if (score > oldHighScore)
        {
            newHighScoreText.SetActive(true);
            HighScoreFillStar.FillUpStar(score, TotalScore);
        }
        else
        {
            HighScoreFillStar.FillUpStar(oldHighScore, TotalScore);
        }

        this.gameObject.SetActive(true);
        gamePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}

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
    /*
    [SerializeField]
    private MaterialPickupStorage materialPickupStorage;
    [SerializeField]
    private MaterialsPanel materialsPanel;
    */
    [SerializeField]
    private SpellsInfoPanel spellsInfoPanel;

    private int oldHighScore = 0;
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
        /*
        Dictionary<int, int> materialIndices = new Dictionary<int, int>();
        List<int> materialIDs = new List<int>();
        List<int> numMaterials = new List<int>();

        foreach (Material material in materialPickupStorage)
        {
            if (materialIndices.ContainsKey(material.materialID))
            {
                numMaterials[materialIndices[material.materialID]]++;
            }
            else
            {
                materialIDs.Add(material.materialID);
                materialIndices[material.materialID] = materialIDs.Count - 1;
                numMaterials.Add(1);
            }
        }
        materialsPanel.ShowMaterials(materialIDs, numMaterials);
        */

        if (unlockedSpellsIDs != null)
        {
            spellsInfoPanel.ShowSpells(unlockedSpellsIDs);
        }

        int score = explorationScore.currentScore;
        scoreText.text = score.ToString();

        if (score > oldHighScore)
        {
            highScoreText.text = score.ToString();
            newHighScoreText.SetActive(true);
        }
        else
        {
            highScoreText.text = oldHighScore.ToString();
        }

        this.gameObject.SetActive(true);
        gamePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}

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
    private MaterialPickupStorage materialPickupStorage;
    [SerializeField]
    private MaterialsPanel materialsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowResults()
    {
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

        int score = explorationScore.currentScore;
        scoreText.text = score.ToString();

        LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(levelID);
        if (score > levelProgression.highScore)
        {
            highScoreText.text = score.ToString();
            newHighScoreText.SetActive(true);
        }
        else
        {
            highScoreText.text = levelProgression.highScore.ToString();
        }

        this.gameObject.SetActive(true);
        gamePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
}

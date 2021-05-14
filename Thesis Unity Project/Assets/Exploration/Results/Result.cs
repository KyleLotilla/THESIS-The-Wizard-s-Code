using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private int levelID;
    [SerializeField]
    private PlayerLevelProgression playerLevelProgression;
    [SerializeField]
    private ExplorationScore explorationScore;
    [SerializeField]
    private MaterialInventory materialInventory;
    [SerializeField]
    private MaterialPickupStorage materialPickupStorage;
    [SerializeField]
    private ResultUI resultUI;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinGame()
    {
        foreach(Material material in materialPickupStorage)
        {
            materialInventory.AddMaterial(material);
        }
        LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(levelID);
        if (levelProgression == null)
        {
            levelProgression = new LevelProgression();
            levelProgression.highScore = 0;
            playerLevelProgression.AddProgression(levelProgression);
        }
        levelProgression.isCompleted = true;
        if (explorationScore.currentScore > levelProgression.highScore)
        {
            levelProgression.highScore = explorationScore.currentScore;
        }
        resultUI.ShowResults();
    }
}

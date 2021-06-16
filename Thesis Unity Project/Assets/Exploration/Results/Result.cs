using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private SpellDatabase spellDatabase;
    [SerializeField]
    private SpellInventory spellInventory;
    [SerializeField]
    private int levelID;
    [SerializeField]
    private LevelDatabase levelDatabase;
    [SerializeField]
    private PlayerLevelProgression playerLevelProgression;
    [SerializeField]
    private ExplorationScore explorationScore;
    /*
    [SerializeField]
    private MaterialInventory materialInventory;
    [SerializeField]
    private MaterialPickupStorage materialPickupStorage;
    */
    [SerializeField]
    private ResultUI resultUI;
    [SerializeField]
    private SaveWriter saveWriter;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinGame()
    {
        /*
        foreach(Material material in materialPickupStorage)
        {
            materialInventory.AddMaterial(material);
        }
        */
        bool isNewlyCompleted = false;
        Level level = levelDatabase.GetLevel(levelID);
        LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(levelID);
        if (levelProgression == null)
        {
            isNewlyCompleted = true;
            levelProgression = new LevelProgression();
            levelProgression.highScore = 0;
            playerLevelProgression.AddProgression(levelProgression);
            foreach (int spellID in level.unlockableSpellsIDs)
            {
                spellInventory.AddSpell(spellDatabase.GetSpell(spellID));
            }
        }

        if (explorationScore.currentScore > levelProgression.highScore)
        {
            levelProgression.highScore = explorationScore.currentScore;
        }

        saveWriter.SaveFile();

        if (isNewlyCompleted)
        {
            resultUI.ShowResults(level.unlockableSpellsIDs);
        }
        else
        {
            resultUI.ShowResults(null);
        }
    }
}

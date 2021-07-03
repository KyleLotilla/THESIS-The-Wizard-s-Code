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
    [SerializeField]
    private ResultUI resultUI;
    [SerializeField]
    private SaveWriter saveWriter;
    [SerializeField]
    private PlayerProfile playerProfile;
    [SerializeField]
    private int tutorialProgression = -1;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinGame()
    {
        bool isNewlyCompleted = false;
        Level level = levelDatabase.GetLevel(levelID);
        LevelProgression levelProgression = playerLevelProgression.GetLevelProgression(levelID);
        if (levelProgression == null)
        {
            isNewlyCompleted = true;
            levelProgression = new LevelProgression();
            levelProgression.levelID = levelID;
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

        if (tutorialProgression > -1)
        {
            playerProfile.tutorialProgression = tutorialProgression;
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

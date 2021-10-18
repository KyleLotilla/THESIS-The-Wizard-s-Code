using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Scoring
{
    public class FillUpStarScoringWithHighScoreOfLevel : MonoBehaviour
    {
        [SerializeField]
        private LevelProgressionDatabase levelProgressionDatabase;
        [SerializeField]
        private FillUpStarScoring fillUpStarScoring;

        public void FillUp(Level level)
        {
            LevelProgression levelProgressionOfLevel = levelProgressionDatabase.GetLevelProgression(level.LevelID);
            if (levelProgressionOfLevel != null)
            {
                fillUpStarScoring.FillUp(levelProgressionOfLevel.HighScore);
            }
        }
    }
}



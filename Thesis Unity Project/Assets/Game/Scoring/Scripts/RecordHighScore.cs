using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Levels;

namespace DLSU.WizardCode.Scoring
{
    public class RecordHighScore : MonoBehaviour
    {
        [SerializeField]
        private IntVariable currentScore;
        [SerializeField]
        private UnityEventOneIntParam onNoNewHighScoreRecorded;
        [SerializeField]
        private UnityEventTwoIntParam onNewHighScoreRecorded;

        public void RecordScore(LevelProgression currentLevelProgression)
        {
            int currentHighScore = currentLevelProgression.HighScore;
            if (currentScore.Value > currentHighScore)
            {
                currentLevelProgression.HighScore = currentScore.Value;
                onNewHighScoreRecorded?.Invoke(currentHighScore, currentScore.Value);
            }
            else
            {
                onNoNewHighScoreRecorded?.Invoke(currentHighScore);
            }
        }
    }

}

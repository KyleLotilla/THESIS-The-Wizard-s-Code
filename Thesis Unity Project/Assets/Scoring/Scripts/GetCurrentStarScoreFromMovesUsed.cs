using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Scoring
{
    public class GetCurrentStarScoreFromMovesUsed : MonoBehaviour
    {
        [SerializeField]
        private IntVariable movesUsed;
        [SerializeField]
        private IntVariable currentScore;
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private UnityEventOneIntParam onCurrentScoreRetrieved;

        public void GetScore()
        {
            currentScore.Value = currentLevel.Value.GetNumberOfStarsObtainedFromMovesUsed(movesUsed.Value);
            onCurrentScoreRetrieved?.Invoke(currentScore.Value);
        }
    }

}

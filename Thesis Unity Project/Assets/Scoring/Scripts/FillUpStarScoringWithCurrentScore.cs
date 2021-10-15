using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Scoring
{
    public class FillUpStarScoringWithCurrentScore : MonoBehaviour
    {
        [SerializeField]
        private IntVariable currentScore;
        [SerializeField]
        private FillUpStarScoring fillUpStarScoring;

        public void FillUp()
        {
            fillUpStarScoring.FillUp(currentScore.Value);
        }
    }

}

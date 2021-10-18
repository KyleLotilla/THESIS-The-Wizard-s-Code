using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Levels;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Scoring
{
    public class CountOverallStarsObtained : MonoBehaviour
    {
        [SerializeField]
        private IntVariable currentOverallStarsObtained;
        [SerializeField]
        private LevelProgressionDatabase levelProgressionDatabase;
        [SerializeField]
        private bool countOnStart;

        private void Start()
        {
            if (countOnStart)
            {
                Count();
            }
        }

        public void Count()
        {
            int starCount = 0;
            foreach (LevelProgression levelProgression in levelProgressionDatabase)
            {
                starCount += levelProgression.HighScore;
            }
            currentOverallStarsObtained.Value = starCount;
        }
    }

}

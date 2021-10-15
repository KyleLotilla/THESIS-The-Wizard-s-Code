using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Levels
{
    [Serializable]
    public class LevelProgression
    {
        [SerializeField]
        private int levelID;
        public int LevelID
        {
            get
            {
                return levelID;
            }
            set
            {
                levelID = value;
            }
        }
        [SerializeField]
        private int highScore = 0;

        public int HighScore
        {
            get
            {
                return highScore;
            }
            set
            {
                highScore = value;
            }
        }
    }

}

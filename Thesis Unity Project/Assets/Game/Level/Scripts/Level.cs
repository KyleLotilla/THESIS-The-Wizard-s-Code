using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.Obstacles;

namespace DLSU.WizardCode.Levels
{
    [CreateAssetMenu(menuName = "Level/Level")]
    public class Level : ScriptableObject
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
        private int worldNumber;
        public int WorldNumber
        {
            get
            {
                return worldNumber;
            }
            set
            {
                worldNumber = value;
            }
        }
        [SerializeField]
        private int levelNumber;
        public int LevelNumber
        {
            get
            {
                return levelNumber;
            }
            set
            {
                levelNumber = value;
            }
        }
        [SerializeField]
        private string sceneName;
        public string SceneName
        {
            get
            {
                return sceneName;
            }
            set
            {
                sceneName = value;
            }
        }
        [SerializeField]
        private string tutorialSceneName;
        public string TutorialSceneName
        {
            get
            {
                return tutorialSceneName;
            }
            set
            {
                tutorialSceneName = value;
            }
        }
        [SerializeField]
        private Sprite levelOverview;
        public Sprite LevelOverview
        {
            get
            {
                return levelOverview;
            }
            set
            {
                levelOverview = value;
            }
        }
        [SerializeField]
        private int overallStarsNeededToUnlock;
        public int OverallStarsNeededToUnlock
        {
            get
            {
                return overallStarsNeededToUnlock;
            }
            set
            {
                overallStarsNeededToUnlock = value;
            }
        }

        [SerializeField]
        private List<ObstacleNumberCountPair> obstacles;
        public IEnumerable<KeyValuePair<Obstacle, int>> ObstalceCounts
        {
            get
            {
                List<KeyValuePair<Obstacle, int>> obstalceCounts = new List<KeyValuePair<Obstacle, int>>();
                foreach (ObstacleNumberCountPair obstacleNumberCountPair in obstacles)
                {
                    KeyValuePair<Obstacle, int> obstacleCount = new KeyValuePair<Obstacle, int>(obstacleNumberCountPair.obstacle, obstacleNumberCountPair.count);
                    obstalceCounts.Add(obstacleCount);
                }
                return obstalceCounts;
            }
        }
        [SerializeField]
        private List<Spell> unlockableSpells;
        [SerializeField]
        public IEnumerable<Spell> UnlockableSpells
        {
            get
            {
                return unlockableSpells;
            }
        }
        [SerializeField]
        private List<int> movesRequirementsForStars;

        public int GetMovesRequirement(int numberOfStars)
        {
            int movesRequirementIndex = numberOfStars - 2;
            Debug.Assert(movesRequirementIndex >= 0 && movesRequirementIndex <= movesRequirementsForStars.Count, "Number Of Stars out of range");
            if (movesRequirementIndex >= 0 && movesRequirementIndex <= movesRequirementsForStars.Count)
            {
                return movesRequirementsForStars[movesRequirementIndex];
            }
            else
            {
                return 0;
            }
        }

        public int GetNumberOfStarsObtainedFromMovesUsed(int movesUsed)
        {
            int numberOfStarsObtained = 1;
            bool hasObtainedStars = false;
            for (int i = movesRequirementsForStars.Count - 1; i >= 0 && !hasObtainedStars; i--)
            {
                if (movesUsed <= movesRequirementsForStars[i])
                {
                    numberOfStarsObtained = i + 2;
                    hasObtainedStars = true;
                }
            }
            return numberOfStarsObtained;
        }
        [Serializable]
        private class ObstacleNumberCountPair
        {
            public Obstacle obstacle;
            public int count;
        }
    }
}

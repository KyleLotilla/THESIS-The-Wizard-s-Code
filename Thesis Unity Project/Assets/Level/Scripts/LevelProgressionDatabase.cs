using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Collections;

namespace DLSU.WizardCode.Levels
{
    [CreateAssetMenu(menuName = "PlayerProgressionSave")]
    public class LevelProgressionDatabase : ScriptableObject, IEnumerable<LevelProgression>
    {
        private SparseArray<int, LevelProgression> levelProgressions;

        private void OnEnable()
        {
            if (levelProgressions != null)
            {
                levelProgressions.Clear();
            }
            else
            {
                levelProgressions = new SparseArray<int, LevelProgression>();
            }
        }
        public void AddProgression(LevelProgression levelProgression)
        {
            if (!levelProgressions.ContainsKey(levelProgression.LevelID))
            {
                levelProgressions[levelProgression.LevelID] = levelProgression;
            }
        }

        public LevelProgression GetLevelProgression(int levelID)
        {
            if (levelProgressions.ContainsKey(levelID))
            {
                return levelProgressions[levelID];
            }
            else
            {
                return null;
            }
        }

        public IEnumerator<LevelProgression> GetEnumerator()
        {
            return ((IEnumerable<LevelProgression>)levelProgressions).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)levelProgressions).GetEnumerator();
        }
    }

}

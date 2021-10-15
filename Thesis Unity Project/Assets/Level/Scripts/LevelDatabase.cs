using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace DLSU.WizardCode.Levels
{
    [CreateAssetMenu(menuName = "Level/LevelDatabase")]
    public class LevelDatabase : ScriptableObject, IEnumerable<Level>
    {
        [SerializeField]
        private List<Level> levels;

        public Level GetLevel(int levelID)
        {
            Debug.Assert(levelID >= 0 && levelID < levels.Count, name + ": Level ID not found");
            if (levelID >= 0 && levelID < levels.Count)
            {
                return levels[levelID];
            }
            else
            {
                return null;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)levels).GetEnumerator();
        }


        IEnumerator<Level> IEnumerable<Level>.GetEnumerator()
        {
            return ((IEnumerable<Level>)levels).GetEnumerator();
        }
    }

}

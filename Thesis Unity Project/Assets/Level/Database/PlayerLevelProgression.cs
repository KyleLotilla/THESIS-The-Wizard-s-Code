using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerProgressionSave")]
public class PlayerLevelProgression : ScriptableObject, IEnumerable<LevelProgression>
{
    private Dictionary<int, LevelProgression> playerLevelProgression;
    private List<LevelProgression> playerLevelProgressionList;

    private void OnEnable()
    {
        if (playerLevelProgression != null)
        {
            playerLevelProgression.Clear();
        }
        else
        {
            playerLevelProgression = new Dictionary<int, LevelProgression>();
        }

        if (playerLevelProgressionList != null)
        {
            playerLevelProgressionList.Clear();
        }
        else
        {
            playerLevelProgressionList = new List<LevelProgression>();
        }
    }
    public void AddProgression(LevelProgression levelProgression)
    {
        if (!playerLevelProgression.ContainsKey(levelProgression.levelID))
        {
            playerLevelProgression[levelProgression.levelID] = levelProgression;
            playerLevelProgressionList.Add(levelProgression);
        }
    }

    public LevelProgression GetLevelProgression(int levelID)
    {
        if (playerLevelProgression.ContainsKey(levelID))
        {
            return playerLevelProgression[levelID];
        }
        else
        {
            return null;
        }
    }

    public IEnumerator<LevelProgression> GetEnumerator()
    {
        return ((IEnumerable<LevelProgression>)playerLevelProgressionList).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)playerLevelProgressionList).GetEnumerator();
    }
}

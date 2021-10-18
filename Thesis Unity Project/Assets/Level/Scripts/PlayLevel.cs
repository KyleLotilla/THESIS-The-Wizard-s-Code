using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels
{
    public class PlayLevel : MonoBehaviour
    {
        [SerializeField]
        private LevelHolder levelHolder;
        [SerializeField]
        private LevelVariable currentLevel;

        public void Play()
        {
            currentLevel.Value = levelHolder.Level;
            string levelSceneName = levelHolder.Level.SceneName;
            SceneManager.LoadScene(levelSceneName);
        }
    }
}


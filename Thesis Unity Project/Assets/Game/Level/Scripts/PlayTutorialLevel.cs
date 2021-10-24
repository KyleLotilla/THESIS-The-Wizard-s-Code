using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Levels
{
    public class PlayTutorialLevel : MonoBehaviour
    {
        [SerializeField]
        private LevelHolder levelHolder;
        [SerializeField]
        private LevelVariable currentLevel;

        public void Play()
        {
            currentLevel.Value = levelHolder.Level;
            string tutorialSceneName = levelHolder.Level.TutorialSceneName;
            Debug.Assert(tutorialSceneName.Length > 0, name + ": No Tutorial Scene Name");
            if (tutorialSceneName.Length > 0)
            {
                SceneManager.LoadScene(tutorialSceneName);
            }
        }
    }

}

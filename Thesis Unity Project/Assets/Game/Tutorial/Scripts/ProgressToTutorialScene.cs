using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.Tags;
using DLSU.WizardCode.Save;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Tutorial
{
    public class ProgressToTutorialScene : MonoBehaviour
    {
        [SerializeField]
        private TutorialSceneDatabase tutorialSceneDatabase;
        [SerializeField]
        private PlayerProfile playerProfile;
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private SaveWriter saveWriter;

        public void ProgressToScene(TutorialScene tutorialScene)
        {
            if (tutorialScene.IsALevelSecene)
            {
                currentLevel.Value = tutorialScene.Level;
            }
            else
            {
                currentLevel.Value = null;
            }
            playerProfile.TutorialProgression = tutorialScene.TutorialProgression;
            saveWriter.SavePlayerProfile();
            saveWriter.SaveXMLFile();
            string tutorialSceneName = tutorialScene.SceneName;
            SceneManager.LoadScene(tutorialSceneName);
        }

        public void ProgressToScene(Tag sceneTag)
        {
            TutorialScene tutorialScene = tutorialSceneDatabase.GetTutorialScene(sceneTag);
            if (tutorialScene != null)
            {
                ProgressToScene(tutorialScene);
            }
        }

        public void ProgressToSceneWithTutorialProgressionOfPlayerProfile()
        {
            TutorialScene tutorialScene = tutorialSceneDatabase.GetTutorialSceneWithTutorialProgression(playerProfile.TutorialProgression);
            if (tutorialScene != null)
            {
                ProgressToScene(tutorialScene);
            }
        }
    }
}

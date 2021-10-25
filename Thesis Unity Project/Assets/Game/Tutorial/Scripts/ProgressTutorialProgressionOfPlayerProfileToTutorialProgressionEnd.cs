using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Tutorial
{
    public class ProgressTutorialProgressionOfPlayerProfileToTutorialProgressionEnd : MonoBehaviour
    {
        [SerializeField]
        private PlayerProfile playerProfile;
        [SerializeField]
        private SaveWriter saveWriter;
        [SerializeField]
        private TutorialSceneDatabase tutorialSceneDatabase;

        public void ProgressToTutorialProgressionEnd()
        {
            playerProfile.TutorialProgression = tutorialSceneDatabase.GetTutorialProgressionEnd();
            saveWriter.SavePlayerProfile();
            saveWriter.SaveXMLFile();
        }
    }

}

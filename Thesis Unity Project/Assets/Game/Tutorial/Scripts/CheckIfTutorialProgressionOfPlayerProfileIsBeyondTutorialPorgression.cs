using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Tutorial
{
    public class CheckIfTutorialProgressionOfPlayerProfileIsBeyondTutorialPorgression : MonoBehaviour
    {
        [SerializeField]
        private PlayerProfile playerProfile;
        [SerializeField]
        private TutorialSceneDatabase tutorialSceneDatabase;
        [SerializeField]
        private UnityEvent tutorialProgressionIsWithinTutorialProgression;
        [SerializeField]
        private UnityEvent tutorialProgressionIsBeyondTutorialProgression;

        public void CheckTutorialProgression()
        {
            if (tutorialSceneDatabase.IsTutorialProgressionEnded(playerProfile.TutorialProgression))
            {
                tutorialProgressionIsBeyondTutorialProgression?.Invoke();
            }
            else
            {
                tutorialProgressionIsWithinTutorialProgression?.Invoke();
            }
        }
    }
}

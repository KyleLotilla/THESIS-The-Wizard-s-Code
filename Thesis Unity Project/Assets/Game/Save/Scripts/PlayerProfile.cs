using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Save
{
    [CreateAssetMenu(menuName = "PlayerProfile")]
    public class PlayerProfile : ScriptableObject
    {
        [SerializeField]
        private string playerName;
        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }
        [SerializeField]
        private Gender gender;
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        [SerializeField]
        private int tutorialProgression;
        public int TutorialProgression
        {
            get
            {
                return tutorialProgression;
            }
            set
            {
                tutorialProgression = value;
            }
        }

        public void SetGenderToMale()
        {
            gender = Gender.MALE;
        }

        public void SetGenderToFemale()
        {
            gender = Gender.FEMALE;
        }
    }

}

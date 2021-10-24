using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Wizard
{
    public class SetWizardGenderInExploration : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private PlayerProfile playerProfile;
        [SerializeField]
        private RuntimeAnimatorController maleAnimatorController;
        [SerializeField]
        private RuntimeAnimatorController femaleAnimatorController;

        // Start is called before the first frame update
        void Start()
        {
            if (playerProfile.Gender == Gender.MALE)
            {
                animator.runtimeAnimatorController = maleAnimatorController;
            }
            else if (playerProfile.Gender == Gender.FEMALE)
            {
                animator.runtimeAnimatorController = femaleAnimatorController;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

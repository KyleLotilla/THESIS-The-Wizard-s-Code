using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (playerProfile.gender == Gender.MALE)
            {
                animator.runtimeAnimatorController = maleAnimatorController;
            }
            else if (playerProfile.gender == Gender.FEMALE)
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

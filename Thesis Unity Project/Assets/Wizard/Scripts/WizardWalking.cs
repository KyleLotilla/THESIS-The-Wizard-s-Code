using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Wizard
{
    public class WizardWalking : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        public void StartWalking()
        {
            animator.SetBool("walk", true);
        }

        public void EndWalking()
        {
            animator.SetBool("walk", false);
        }
    }

}

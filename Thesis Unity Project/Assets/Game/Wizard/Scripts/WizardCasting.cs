using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Wizard
{
    public class WizardCasting : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private UnityEvent onWizardRegularCastAnimationEnd;
        [SerializeField]
        private UnityEvent onWizardHoldingCastStartUpAnimationEnd;
        [SerializeField]
        private UnityEvent onWizardHoldingCastEnd;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoRegularCast()
        {
            animator.SetBool("regularCast", true);
        }

        public void OnWizardRegularCastAnimationEnd()
        {
            animator.SetBool("regularCast", false);
            onWizardRegularCastAnimationEnd?.Invoke();
        }

        public void DoHoldingCast()
        {
            animator.SetBool("startHoldingCast", true);
        }

        public void OnWizardHoldingCastStartUpAnimationEnd()
        {
            animator.SetBool("endHoldingCast", false);
            animator.SetBool("startHoldingCast", false);
            onWizardHoldingCastStartUpAnimationEnd?.Invoke();
        }

        public void EndHoldingCast()
        {
            animator.SetBool("endHoldingCast", true);
        }

        public void OnWizardHoldingCastEnd()
        {
            onWizardHoldingCastEnd?.Invoke();
        }
    }

}

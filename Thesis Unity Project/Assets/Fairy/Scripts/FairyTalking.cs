using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Fairy
{
    public class FairyTalking : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private UnityEvent onFairyTalkAnimationStart;
        [SerializeField]
        private UnityEvent onFairyTalkAnimationEnd;

        public void StartTalking()
        {
            animator.SetBool("talk", true);
            onFairyTalkAnimationStart?.Invoke();
        }

        public void OnFairyTalkAnimationEnd()
        {
            animator.SetBool("talk", false);
            onFairyTalkAnimationEnd?.Invoke();
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Util
{
    public class DestroyAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string destroyAnimationStringParameter;
        [SerializeField]
        private UnityEvent onDestroyAnimationStart;
        [SerializeField]
        private UnityEvent onDestroyAnimationEnd;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartDestroyAnimation()
        {
            onDestroyAnimationStart?.Invoke();
            animator.SetBool(destroyAnimationStringParameter, true);
        }

        public void OnDestroyAnimationEnd()
        {
            onDestroyAnimationEnd?.Invoke();
            Destroy(gameObject);
        }
    }
}


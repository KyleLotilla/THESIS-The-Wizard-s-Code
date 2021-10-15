using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Exploration.Results
{
    public class OpenGoalDoor : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private UnityEvent onDoorOpened;

        public void OpenDoor()
        {
            animator.SetBool("open", true);
        }

        public void OnDoorOpened()
        {
            onDoorOpened?.Invoke();
        }
    }

}

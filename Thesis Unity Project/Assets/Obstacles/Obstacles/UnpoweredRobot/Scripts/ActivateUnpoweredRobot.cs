using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Obstacles.UnpoweredRobot
{
    public class ActivateUnpoweredRobot : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private UnityEvent onRobotActivated;

        public void Activate()
        {
            animator.SetBool("activate", true);
        }

        public void OnRobotActivated()
        {
            onRobotActivated?.Invoke();
        }
    }

}

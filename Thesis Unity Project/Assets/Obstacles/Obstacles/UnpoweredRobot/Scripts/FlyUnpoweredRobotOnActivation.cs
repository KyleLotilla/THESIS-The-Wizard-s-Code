using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Physics;

namespace DLSU.WizardCode.Obstacles.UnpoweredRobot
{
    public class FlyUnpoweredRobotOnActivation : MonoBehaviour
    {
        [SerializeField]
        private LimitedDistanceVerticalMovement limitedDistanceVerticalMovementOfRobot;
        [SerializeField]
        private float flyDistance;
        [Min(0.0f)]
        [SerializeField]
        private float flySpeed;

        public void OnRobotActivated()
        {
            limitedDistanceVerticalMovementOfRobot.Move(flyDistance, flySpeed);
        }
    }
}


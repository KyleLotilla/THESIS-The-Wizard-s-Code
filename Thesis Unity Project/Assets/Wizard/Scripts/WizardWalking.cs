using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Wizard
{
    public class WizardWalking : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private Animator animator;

        private bool isWalking = false;
        public bool IsWalking
        {
            get
            {
                return isWalking;
            }
            set
            {
                isWalking = value;
            }
        }
        [SerializeField]
        private UnityEvent onWalkingEnd;
        [SerializeField]
        private bool canWalkWithKeyboardInEditor = false;
        [SerializeField]
        private float keyboardWalkDistance;
        [SerializeField]
        private float keyboardWalkSpeed;

        private float currentwalkingVelocity;
        private float targetTravelDistance;
        private float currentDistanceTraveled;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (this.isWalking)
            {
                this.UpdateMovement();
            }
#if UNITY_EDITOR
            else if (canWalkWithKeyboardInEditor)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Walk(keyboardWalkDistance, keyboardWalkSpeed);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Walk(keyboardWalkDistance, -keyboardWalkSpeed);
                }
            }
#endif
        }

        public void Walk(float distance, float walkingVelocity)
        {
            if (distance != 0.0f)
            {
                targetTravelDistance = distance;
                currentDistanceTraveled = 0.0f;
                this.currentwalkingVelocity = walkingVelocity;
                isWalking = true;
                animator.SetBool("walking", true);

                Vector3 wizardEulerRotation = this.transform.eulerAngles;
                if (walkingVelocity > 0)
                {
                    if (wizardEulerRotation.y != 0.0f)
                    {
                        wizardEulerRotation.y = -180.0f;
                        this.transform.Rotate(wizardEulerRotation);
                    }
                }
                else if (walkingVelocity < 0)
                {
                    if (wizardEulerRotation.y != 180.0f)
                    {
                        wizardEulerRotation.y = 180.0f;
                        this.transform.Rotate(wizardEulerRotation);
                    }
                }
            }
        }

        private void UpdateMovement()
        {
            float distanceTraveledInCurrentFrame = currentwalkingVelocity * Time.fixedDeltaTime;
            Vector2 newPosition = this.rigidBody.position;
            newPosition.x += distanceTraveledInCurrentFrame;
            rigidBody.MovePosition(newPosition);
            currentDistanceTraveled += Mathf.Abs(distanceTraveledInCurrentFrame);
            if (currentDistanceTraveled >= targetTravelDistance)
            {
                StopWalking();
            }
        }

        public void StopWalking()
        {
            if (isWalking)
            {
                isWalking = false;
                animator.SetBool("walking", false);
                targetTravelDistance = 0.0f;
                currentDistanceTraveled = 0.0f;
                currentwalkingVelocity = 0.0f;
                onWalkingEnd?.Invoke();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Physics
{
    public class LimitedDistanceHorizontalMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidBody;
        private bool isMoving = false;
        public bool IsWalking
        {
            get
            {
                return isMoving;
            }
            set
            {
                isMoving = value;
            }
        }
        [SerializeField]
        private bool canChangeDirectionBasedOnVelocity = false;
        [SerializeField]
        private bool destroyOnMoveEnd = false;
        [SerializeField]
        private UnityEvent onMoveStart;
        [SerializeField]
        private UnityEvent onMoveEnd;
        [SerializeField]
        private bool canMoveWithKeyboardInEditor = false;
        [SerializeField]
        private float keyboardMoveDistance;
        [SerializeField]
        private float keyboardMoveSpeed;

        private float currentVelocity;
        private float targetTravelDistance;
        private float currentDistanceTraveled;

        void FixedUpdate()
        {
            if (this.isMoving)
            {
                this.UpdateMovement();
            }
#if UNITY_EDITOR
            else if (canMoveWithKeyboardInEditor)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    Move(keyboardMoveDistance, keyboardMoveSpeed);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    Move(keyboardMoveDistance, -keyboardMoveSpeed);
                }
            }
#endif
        }

        public void Move(float distance, float velocity)
        {
            if (distance != 0.0f)
            {
                targetTravelDistance = distance;
                currentDistanceTraveled = 0.0f;
                this.currentVelocity = velocity;
                isMoving = true;

                if (canChangeDirectionBasedOnVelocity)
                {
                    Vector3 eulerRotation = this.transform.eulerAngles;
                    if (velocity > 0)
                    {
                        if (eulerRotation.y != 0.0f)
                        {
                            eulerRotation.y = -180.0f;
                            this.transform.Rotate(eulerRotation);
                        }
                    }
                    else if (velocity < 0)
                    {
                        if (eulerRotation.y != 180.0f)
                        {
                            eulerRotation.y = 180.0f;
                            this.transform.Rotate(eulerRotation);
                        }
                    }
                }

                onMoveStart?.Invoke();
            }
        }

        private void UpdateMovement()
        {
            float distanceTraveledInCurrentFrame = currentVelocity * Time.fixedDeltaTime;
            Vector2 newPosition = this.rigidBody.position;
            newPosition.x += distanceTraveledInCurrentFrame;
            rigidBody.MovePosition(newPosition);
            currentDistanceTraveled += Mathf.Abs(distanceTraveledInCurrentFrame);
            if (currentDistanceTraveled >= targetTravelDistance)
            {
                StopMovement();
            }
        }

        public void StopMovement()
        {
            if (isMoving)
            {
                isMoving = false;
                targetTravelDistance = 0.0f;
                currentDistanceTraveled = 0.0f;
                currentVelocity = 0.0f;
                onMoveEnd?.Invoke();
                if (destroyOnMoveEnd)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}

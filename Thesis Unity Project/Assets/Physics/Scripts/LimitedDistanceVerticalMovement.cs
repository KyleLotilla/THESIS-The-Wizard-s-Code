using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.WizardCode.Physics
{
    public class LimitedDistanceVerticalMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidBody;
        private bool isMoving = false;
        public bool IsMoving
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
                if (Input.GetKey(KeyCode.W))
                {
                    Move(keyboardMoveDistance, keyboardMoveSpeed);
                }
                else if (Input.GetKey(KeyCode.S))
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
                onMoveStart?.Invoke();
            }
        }

        private void UpdateMovement()
        {
            float distanceTraveledInCurrentFrame = currentVelocity * Time.fixedDeltaTime;
            Vector2 newPosition = this.rigidBody.position;
            newPosition.y += distanceTraveledInCurrentFrame;
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
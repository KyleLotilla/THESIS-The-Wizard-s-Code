using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT,
    RIGHT
}

public class WizardMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Animator animator;
    private float walkingVelocity;
    [SerializeField]
    private Direction _direction = Direction.RIGHT;
    public Direction direction
    {
        get
        {
            return _direction;
        }
        private set
        {
            _direction = value;
        }
    }
    [SerializeField]
    private float destDistance;
    [SerializeField]
    private float currentDistance;
    public bool isWalking { get; private set; } = false;


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
        /*
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                Walk(4.0f, 11.0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Walk(4.0f, -11.0f);
            }
        }
        */
    }

    public void Walk(float distance, float walkingVelocity)
    {
        if (distance != 0.0f)
        {
            destDistance = distance;
            currentDistance = 0.0f;
            this.walkingVelocity = walkingVelocity;
            isWalking = true;
            animator.SetBool("walking", true);
            Vector3 eulerAngles = this.transform.eulerAngles;

            if (walkingVelocity > 0)
            {
                direction = Direction.RIGHT;
                if (eulerAngles.y != 0.0f)
                {
                    eulerAngles.y = -180.0f;
                    this.transform.Rotate(eulerAngles);
                }
            }
            else if (walkingVelocity < 0)
            {
                direction = Direction.LEFT;
                if (eulerAngles.y != 180.0f)
                {
                    eulerAngles.y = 180.0f;
                    this.transform.Rotate(eulerAngles);
                }
            }
        }
    }

    private void UpdateMovement()
    {
        float deltaDisplacement = walkingVelocity * Time.fixedDeltaTime;
        Vector2 deltaPosition = this.rigidBody.position;
        deltaPosition.x += deltaDisplacement;
        rigidBody.MovePosition(deltaPosition);
        currentDistance += Mathf.Abs(deltaDisplacement);
        if (currentDistance >= destDistance)
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
            destDistance = 0.0f;
            currentDistance = 0.0f;
            walkingVelocity = 0.0f;
        }
    }

    
}

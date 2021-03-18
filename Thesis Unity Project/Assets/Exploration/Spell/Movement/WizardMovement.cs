using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
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
    [SerializeField]
    private float walkingSpeed;
    [SerializeField]
    private Direction direction = Direction.RIGHT;
    [SerializeField]
    private float destDisplacement;
    [SerializeField]
    private float currentDisplacement;
    public bool isWalking { get; private set; } = false;
    public bool isCasting { get; private set; } = false;


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
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                Walk(2.0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Walk(-2.0f);
            }
        }
    }

    public void Cast()
    {
        animator.SetBool("casting", true);
        isCasting = true;

    }

    public int checkDirection()
    {
        if(direction == Direction.RIGHT)
        {
            return 1;
        }
        else 
        {
            return 0;
        }
        
    }

    public void Walk(float displacement)
    {
        if (displacement != 0.0f)
        {
            destDisplacement = displacement;
            currentDisplacement = 0.0f;
            isWalking = true;
            animator.SetBool("walking", true);
            Vector3 eulerAngles = this.transform.eulerAngles;

            if (displacement > 0)
            {
                direction = Direction.RIGHT;
                if (eulerAngles.y != 0.0f)
                {
                    eulerAngles.y = -180.0f;
                    this.transform.Rotate(eulerAngles);
                }
            }
            else if (displacement < 0)
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
        float deltaDisplacement = walkingSpeed * Time.fixedDeltaTime;
        if (direction == Direction.LEFT)
        {
            deltaDisplacement = -deltaDisplacement;
        }
        Vector2 deltaPosition = this.rigidBody.position;
        deltaPosition.x += deltaDisplacement;
        rigidBody.MovePosition(deltaPosition);
        currentDisplacement += deltaDisplacement;
        if ((direction == Direction.LEFT && currentDisplacement <= destDisplacement) || (direction == Direction.RIGHT && currentDisplacement >= destDisplacement))
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
            destDisplacement = 0.0f;
            currentDisplacement = 0.0f;
        }
    }

    public void StopCasting()
    {
        if (isCasting)
        {
            isCasting = false;
            animator.SetBool("casting", false);
            Debug.Log("Setting casting to false");
        }
    }
}

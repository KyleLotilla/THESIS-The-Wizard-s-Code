using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float flyingSpeed;

    [SerializeField]
    private float destDisplacement;
    [SerializeField]
    private float currentDisplacement;
    public bool isFlying { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isFlying)
        {
            this.UpdateMovement();
        }
    }

    public void Fly(float displacement)
    {
        if (displacement != 0.0f)
        {
            
            destDisplacement = displacement;
            currentDisplacement = 0.0f;
            isFlying = true;
        }
    }

    private void UpdateMovement()
    {
        float deltaDisplacement = flyingSpeed * Time.fixedDeltaTime;
        Vector2 deltaPosition = this.rigidBody.position;
        deltaPosition.y += deltaDisplacement;
        rigidBody.MovePosition(deltaPosition);
        currentDisplacement += deltaDisplacement;
        if(deltaPosition.y >= 10.0f)
        {
            Destroy(this.gameObject);
        }
    }


}

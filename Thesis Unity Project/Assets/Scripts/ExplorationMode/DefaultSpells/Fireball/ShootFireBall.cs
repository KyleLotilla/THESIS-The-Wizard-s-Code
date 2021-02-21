using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject FireBallPrefab;
    [SerializeField]
    private float FireBallSpeed;

    private bool isRunning = false;
    private GameObject FireBallInstance;

    public override void Execute()
    {
        Transform wizardtransform = this.Wizard.transform;
        if(wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -0.5f;
            this.FireBallSpeed *= -0.5f;
        }
        Vector3 FireBallPosition = wizardtransform.position + this.offset;
        this.FireBallInstance = Instantiate(this.FireBallPrefab, FireBallPosition, wizardtransform.rotation);
        if (this.FireBallInstance)
        {
            FireballMovement fireballmovement = this.FireBallInstance.GetComponent<FireballMovement>();
            if (fireballmovement)
            {
                this.isRunning = true;
                this.enabled = true;
                fireballmovement.FireballSpeed = this.FireBallSpeed;
            }
        }
    }


    public override bool isFinishedExecuting()
    {
        return !this.isRunning;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isRunning)
        {
            if (!(this.FireBallInstance))
            {
                this.isRunning = false;
                this.enabled = false;
            }
        }
    }
}

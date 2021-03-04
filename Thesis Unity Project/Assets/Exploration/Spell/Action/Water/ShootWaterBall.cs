using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWaterBall : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject WaterBallPrefab;
    [SerializeField]
    private float WaterBallSpeed;

    private GameObject WaterBallInstance;
    private WizardMovement wizardmovement;
    private bool spawned = false;
    protected override void Execute()
    {
        this.wizardmovement = this.wizard.GetComponent<WizardMovement>();
        if (this.wizardmovement)
        {
            this.wizardmovement.Cast();
        }
    }

    public void SpawnWaterBall()
    {
        spawned = true;
        Transform wizardtransform = this.wizard.transform;
        if (wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -0.5f;
            this.WaterBallSpeed *= -0.5f;
        }
        Vector3 WaterBallPosition = wizardtransform.position + this.offset;
        this.WaterBallInstance = Instantiate(this.WaterBallPrefab, WaterBallPosition, wizardtransform.rotation);
        if (this.WaterBallInstance)
        {
            WaterBallMovement waterballmovement = this.WaterBallInstance.GetComponent<WaterBallMovement>();
            if (waterballmovement)
            {
                waterballmovement.WaterBallSpeed = this.WaterBallSpeed;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (this.isExecuting)
        {
            if (!wizardmovement.isCasting && !spawned)
            {
                SpawnWaterBall();
            }
            if (!(this.WaterBallInstance) && spawned)
            {
                EndExecution();
                spawned = false;
            }
        }
    }
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject FireBallPrefab;
    [SerializeField]
    private float FireBallSpeed;

    private GameObject FireBallInstance;
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

    public void SpawnFireball()
    {
        spawned = true;
        Transform wizardtransform = this.wizard.transform;
        if (wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -1f;
            this.FireBallSpeed *= -1f;
        }
        Vector3 FireBallPosition = wizardtransform.position + this.offset;
        this.FireBallInstance = Instantiate(this.FireBallPrefab, FireBallPosition, wizardtransform.rotation);
        if (this.FireBallInstance)
        {
            FireballMovement fireballmovement = this.FireBallInstance.GetComponent<FireballMovement>();
            if (fireballmovement)
            {
                fireballmovement.FireballSpeed = this.FireBallSpeed;
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
                SpawnFireball();
            }
            else if (!(this.FireBallInstance) && spawned)
            {
                EndExecution();
                spawned = false;
            }
        }
    }
}
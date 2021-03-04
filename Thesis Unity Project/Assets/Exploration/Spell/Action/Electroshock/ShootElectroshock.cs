﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootElectroshock : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject ElectroshockPrefab;
    [SerializeField]
    private float ElectroshockSpeed;

    private GameObject ElectroshockInstance;
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

    public void SpawnElectroshock()
    {
        spawned = true;
        Transform wizardtransform = this.wizard.transform;
        if (wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -0.5f;
            this.ElectroshockSpeed *= -0.5f;
        }
        Vector3 ElectroshockPosition = wizardtransform.position + this.offset;
        this.ElectroshockInstance = Instantiate(this.ElectroshockPrefab, ElectroshockPosition, wizardtransform.rotation);
        if (this.ElectroshockInstance)
        {
            ElectroshockMovement electroshockmovement = this.ElectroshockInstance.GetComponent<ElectroshockMovement>();
            if (electroshockmovement)
            {
                electroshockmovement.ElectroshockSpeed = this.ElectroshockSpeed;
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
                SpawnElectroshock();
            }
            if (!(this.ElectroshockInstance) && spawned)
            {
                EndExecution();
                spawned = false;
            }
        }
    }
}
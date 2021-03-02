using System;
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
    protected override void Execute()
    {
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
            if (!(this.ElectroshockInstance))
            {
                EndExecution();
            }
        }
    }
}
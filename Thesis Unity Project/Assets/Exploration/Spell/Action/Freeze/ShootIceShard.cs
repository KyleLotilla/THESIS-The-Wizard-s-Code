using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIceShard : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject IceShardPrefab;
    [SerializeField]
    private float IceShardSpeed;

    private GameObject IceShardInstance;
    protected override void Execute()
    {
        Transform wizardtransform = this.wizard.transform;
        if (wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -0.5f;
            this.IceShardSpeed *= -0.5f;
        }
        Vector3 IceShardPosition = wizardtransform.position + this.offset;
        this.IceShardInstance = Instantiate(this.IceShardPrefab, IceShardPosition, wizardtransform.rotation);
        if (this.IceShardInstance)
        {
            IceShardMovement iceshardmovement = this.IceShardInstance.GetComponent<IceShardMovement>();
            if (iceshardmovement)
            {
                iceshardmovement.IceShardSpeed = this.IceShardSpeed;
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
            if (!(this.IceShardInstance))
            {
                EndExecution();
            }
        }
    }
}
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

    public void SpawnIceShard()
    {
        spawned = true;
        Transform wizardtransform = this.wizard.transform;
        if (wizardtransform.rotation.eulerAngles.y == 180.0f)
        {
            this.offset.x *= -1f;
            this.IceShardSpeed *= -1f;
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
            if (!wizardmovement.isCasting && !spawned)
            {
                SpawnIceShard();
            }
            if (!(this.IceShardInstance) && spawned)
            {
                EndExecution();
                spawned = false;
            }
        }
    }
}
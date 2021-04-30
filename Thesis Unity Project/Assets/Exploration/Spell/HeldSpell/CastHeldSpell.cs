using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHeldSpell : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject spellPrefab;

    private DestroyHandler spellDestroyHandler;
    private WizardCasting wizardCasting;

    protected override void Execute()
    {
        wizardCasting = this.wizard.GetComponent<WizardCasting>();
        if (wizardCasting != null)
        {
            wizardCasting.OnCastingEnd += OnCastingEnd;
            wizardCasting.CastHold();
        }
    }

    private void OnCastingEnd()
    {
        wizardCasting.OnCastingEnd -= OnCastingEnd;
        SpawnSpell();
    }

    public void SpawnSpell()
    {
        Transform wizardtransform = wizard.transform;
        Vector3 wizardRotation = wizardtransform.rotation.eulerAngles;
        if (wizardRotation.y == 180.0f)
        {
            this.offset.x *= -1f;
        }
        Vector3 spellPosition = wizardtransform.position + this.offset;
        GameObject spellObject = Instantiate(spellPrefab, spellPosition, wizardtransform.rotation);
        if (spellObject != null)
        {
            spellDestroyHandler = spellObject.GetComponent<DestroyHandler>();
            if (spellDestroyHandler != null)
            {
                spellDestroyHandler.OnGameObjectDestroy += OnSpellDestroy;
            }
        }
    }

    private void OnSpellDestroy()
    {
        wizardCasting.EndCastHold();
        EndExecution();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
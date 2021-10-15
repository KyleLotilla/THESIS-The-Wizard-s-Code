using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Wizard;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Actions
{
    public class HoldingCastSpellAction : Action
    {
        [SerializeField]
        private GameObjectVariable wizard;
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private GameObject spellPrefab;
        private Transform wizardTransform;
        private WizardCasting wizardCasting;

        protected override bool StartExecution()
        {
            Debug.Assert(wizard.Value != null, name + ": No GameObject found for the Wizard GameObject Variable");
            wizardCasting = wizard.Value.GetComponent<WizardCasting>();
            if (wizardCasting != null)
            {
                wizardTransform = wizard.Value.transform;
                wizardCasting.DoHoldingCast();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SpawnSpell()
        {
            Vector3 wizardEulerRotation = wizardTransform.rotation.eulerAngles;
            Vector3 offset = actionRange.Offset;
            if (wizardEulerRotation.y == 180.0f)
            {
                offset.x *= -1f;
            }
            Vector3 spellPosition = wizardTransform.position + offset;
            GameObject spellObject = Instantiate(spellPrefab, spellPosition, wizardTransform.rotation);
        }

        public void EndHoldingCast()
        {
            wizardCasting.EndHoldingCast();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}

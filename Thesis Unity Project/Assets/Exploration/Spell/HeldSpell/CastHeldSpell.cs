using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLSU.WizardCode.Actions
{
    public class CastHeldSpell : Action
    {
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private GameObject spellPrefab;
        [SerializeField]
        private AudioClip audioClip;
        [SerializeField]
        private GameObject oneShotAudioPrefab;


        private DestroyHandler spellDestroyHandler;
        private WizardCasting wizardCasting;

        protected override bool StartExecution()
        {
            //wizardCasting = this.Wizard.GetComponent<WizardCasting>();
            if (wizardCasting != null)
            {
                wizardCasting.OnCastingHoldStartEnd += OnCastingHoldStartEnd;
                wizardCasting.CastHold();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnCastingHoldStartEnd()
        {
            wizardCasting.OnCastingHoldStartEnd -= OnCastingHoldStartEnd;
            SpawnSpell();
            GameObject oneShotAudioObject = Instantiate(oneShotAudioPrefab);
            if (oneShotAudioObject != null)
            {
                OneShotAudioClip oneShotAudioClip = oneShotAudioObject.GetComponent<OneShotAudioClip>();
                if (oneShotAudioClip != null)
                {
                    oneShotAudioClip.PlayClip(audioClip);
                }
            }
        }

        public void SpawnSpell()
        {
            /*
            Transform wizardtransform = Wizard.transform;
            Vector3 wizardRotation = wizardtransform.rotation.eulerAngles;
            Vector3 offset = actionRange.offset;
            if (wizardRotation.y == 180.0f)
            {
                offset.x *= -1f;
            }
            Vector3 spellPosition = wizardtransform.position + offset;
            GameObject spellObject = Instantiate(spellPrefab, spellPosition, wizardtransform.rotation);
            if (spellObject != null)
            {
                spellDestroyHandler = spellObject.GetComponent<DestroyHandler>();
                if (spellDestroyHandler != null)
                {
                    spellDestroyHandler.OnGameObjectDestroy += OnSpellDestroy;
                }
            }
            */
        }

        private void OnSpellDestroy()
        {
            wizardCasting.OnCastingHoldEnd += OnCastingHoldEnd;
            wizardCasting.EndCastHold();
        }

        private void OnCastingHoldEnd()
        {
            wizardCasting.OnCastingHoldEnd -= OnCastingHoldEnd;
            EndExecution();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}

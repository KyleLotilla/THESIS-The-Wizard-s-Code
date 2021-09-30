using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class ShootProjectile : Action
    {
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private GameObject projectilePrefab;
        [SerializeField]
        private AudioClip audioClip;
        [SerializeField]
        private GameObject oneShotAudioPrefab;

        private DestroyHandler projectileDestroyHandler;
        private WizardCasting wizardCasting;
        // Start is called before the first frame update

        protected override bool StartExecution()
        {
            /*
            wizardCasting = Wizard.GetComponent<WizardCasting>();
            if (wizardCasting)
            {
                wizardCasting.OnCastingEnd += OnCastingEnd;
                wizardCasting.Cast();
            }
            */
            return false;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCastingEnd()
        {
            wizardCasting.OnCastingEnd -= OnCastingEnd;
            SpawnProjectile();
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

        public void SpawnProjectile()
        {
            /*
            Transform wizardtransform = Wizard.transform;
            Vector3 wizardRotation = wizardtransform.rotation.eulerAngles;
            Vector3 offset = actionRange.offset;
            Vector2 velocity = actionRange.velocity;
            if (wizardRotation.y == 180.0f)
            {
                offset.x *= -1f;
                velocity.x *= -1.0f;
            }
            Vector3 projectilePosition = wizardtransform.position + offset;
            GameObject projectileObject = Instantiate(projectilePrefab, projectilePosition, wizardtransform.rotation);
            if (projectileObject != null)
            {
                projectileDestroyHandler = projectileObject.GetComponent<DestroyHandler>();
                if (projectileDestroyHandler != null)
                {
                    projectileDestroyHandler.OnGameObjectDestroy += OnProjectileDestroy;
                }
                ProjectileMovement projectileMovement = projectileObject.GetComponent<ProjectileMovement>();
                if (projectileMovement != null)
                {
                    projectileMovement.projectileSpeed = velocity;
                    projectileMovement.maxRange = actionRange.maxRange;
                }

            }
            */
        }

        private void OnProjectileDestroy()
        {
            projectileDestroyHandler.OnGameObjectDestroy -= OnProjectileDestroy;
            EndExecution();
        }
    }
}


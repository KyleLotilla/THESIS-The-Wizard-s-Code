using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Wizard;
using DLSU.WizardCode.ScriptableObjectVariables;
using DLSU.WizardCode.Physics;

namespace DLSU.WizardCode.Actions
{
    public class ShootProjectileAction : Action
    {
        [SerializeField]
        private ActionRange actionRange;
        [SerializeField]
        private ActionVelocity actionVelocity;
        [SerializeField]
        private GameObjectVariable wizard;
        [SerializeField]
        private GameObject projectilePrefab;

        private WizardCasting wizardCasting;
        private Transform wizardTransform;
        // Start is called before the first frame update

        protected override bool StartExecution()
        {
            Debug.Assert(wizard.Value != null, name + ": No GameObject found for the Wizard GameObject Variable");
            wizardCasting = wizard.Value.GetComponent<WizardCasting>();
            if (wizardCasting != null)
            {
                wizardTransform = wizard.Value.transform;
                wizardCasting.DoRegularCast();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShootProjectile()
        {
            Vector3 wizardEulerRotation = wizardTransform.rotation.eulerAngles;
            Vector3 offset = actionRange.Offset;
            Vector2 velocity = actionVelocity.Velocity;
            if (wizardEulerRotation.y == 180.0f)
            {
                offset.x *= -1f;
                velocity.x *= -1.0f;
            }
            Vector3 projectilePosition = wizardTransform.position + offset;
            GameObject projectileObject = Instantiate(projectilePrefab, projectilePosition, wizardTransform.rotation);
            if (projectileObject != null)
            {
                LimitedDistanceHorizontalMovement projectileLimitedDistanceMovement = projectileObject.GetComponent<LimitedDistanceHorizontalMovement>();
                if (projectileLimitedDistanceMovement != null)
                {
                    projectileLimitedDistanceMovement.Move(actionRange.MaxRange.x, velocity.x);
                }
            }
            
        }
    }
}


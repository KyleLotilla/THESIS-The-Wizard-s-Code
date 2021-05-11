using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : Action
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private GameObject oneShotAudioPrefab;

    private DestroyHandler projectileDestroyHandler;
    private WizardCasting wizardCasting;
    // Start is called before the first frame update

    protected override void Execute()
    {
        wizardCasting = wizard.GetComponent<WizardCasting>();
        if (wizardCasting)
        {
            wizardCasting.OnCastingEnd += OnCastingEnd;
            wizardCasting.Cast();
        }
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
        Transform wizardtransform = wizard.transform;
        Vector3 wizardRotation = wizardtransform.rotation.eulerAngles;
        if (wizardRotation.y == 180.0f)
        {
            this.offset.x *= -1f;
        }
        Vector3 projectilePosition = wizardtransform.position + this.offset;
        GameObject projectileObject = Instantiate(projectilePrefab, projectilePosition, wizardtransform.rotation);
        if (projectileObject != null)
        {
            projectileDestroyHandler = projectileObject.GetComponent<DestroyHandler>();
            if (projectileDestroyHandler != null)
            {
                projectileDestroyHandler.OnGameObjectDestroy += OnProjectileDestroy;
            }

            if (wizardRotation.y == 180.0f)
            {
                ProjectileMovement projectileMovement = projectileObject.GetComponent<ProjectileMovement>();
                if (projectileMovement != null)
                {
                    Vector2 projectileSpeed = projectileMovement.projectileSpeed;
                    projectileSpeed.x *= -1.0f;
                    projectileMovement.projectileSpeed = projectileSpeed;
                }
            }
        }
    }

    private void OnProjectileDestroy()
    {
        projectileDestroyHandler.OnGameObjectDestroy -= OnProjectileDestroy;
        EndExecution();
    }
}

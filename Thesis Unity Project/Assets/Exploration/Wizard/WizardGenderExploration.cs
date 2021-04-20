using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardGenderExploration : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private PlayerProfile playerProfile;
    [SerializeField]
    private RuntimeAnimatorController femaleAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        if (playerProfile.gender == Gender.FEMALE)
        {
            animator.runtimeAnimatorController = femaleAnimatorController;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

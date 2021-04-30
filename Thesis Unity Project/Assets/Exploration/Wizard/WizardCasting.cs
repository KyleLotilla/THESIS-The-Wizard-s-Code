using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCastingEnd();

public class WizardCasting : MonoBehaviour
{
    public event OnCastingEnd OnCastingEnd;

    [SerializeField]
    private Animator animator;
    public bool isCasting { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cast()
    {
        animator.SetBool("casting", true);
        isCasting = true;
    }

    public void CastHold()
    {
        animator.SetBool("casting_hold", true);
        isCasting = true;
    }

    public void EndCastHold()
    {
        animator.SetBool("casting_hold", false);
        isCasting = false;
    }

    public void OnCastingAnimationEnd()
    {
        if (isCasting)
        {
            isCasting = false;
            animator.SetBool("casting", false);
            OnCastingEnd?.Invoke();
        }
    }

    public void OnCastingHoldStartAnimationEnd()
    {
        if (isCasting)
        {
            OnCastingEnd?.Invoke();
        }
    }
}

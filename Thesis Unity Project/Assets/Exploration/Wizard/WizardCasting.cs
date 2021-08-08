using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnCastingEnd();
public delegate void OnCastingHoldStartEnd();
public delegate void OnCastingHoldEnd();

public class WizardCasting : MonoBehaviour
{
    public event OnCastingEnd OnCastingEnd;
    public event OnCastingHoldStartEnd OnCastingHoldStartEnd;
    public event OnCastingHoldEnd OnCastingHoldEnd;

    [SerializeField]
    private Animator animator;
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
    }

    public void CastHold()
    {
        animator.SetBool("casting_hold", true);
    }

    public void EndCastHold()
    {
        animator.SetBool("casting_hold", false);
    }

    public void OnCastingAnimationEnd()
    {
        animator.SetBool("casting", false);
        OnCastingEnd?.Invoke();
    }

    public void OnCastingHoldStartAnimationEnd()
    {
        OnCastingHoldStartEnd?.Invoke();
    }

    public void OnCastingHoldAnimationEnd()
    {
        OnCastingHoldEnd?.Invoke();
    }
}

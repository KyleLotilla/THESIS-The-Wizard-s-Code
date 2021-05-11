using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnFairyTalkingEnd();

public class FairyTalking : MonoBehaviour
{
    public event OnFairyTalkingEnd OnFairyTalkingEnd;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTalking()
    {
        audioSource.Play();
        animator.SetBool("talk", true);
    }

    public void OnFairyTalkAnimationEnd()
    {
        animator.SetBool("talk", false);
        OnFairyTalkingEnd?.Invoke();
        OnFairyTalkingEnd = null;
    }
}

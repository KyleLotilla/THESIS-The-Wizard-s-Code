using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubbleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private GameObject oneShotAudioPrefab;
    [SerializeField]
    private ScoreGiver scoreGiver;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Ice")
            {
                animator.SetBool("Disappear", true);
                scoreGiver.GiveScore();
                GameObject oneShotAudioObject = Instantiate(oneShotAudioPrefab);
                if (oneShotAudioObject != null)
                {
                    OneShotAudioClip oneShotAudioClip = oneShotAudioObject.GetComponent<OneShotAudioClip>();
                    if (oneShotAudioClip != null)
                    {
                        oneShotAudioClip.PlayClip(audioClip);
                    }
                }
                collider.enabled = false;
            }
            else
            {
                scoreGiver.PenalizeScore();
            }
        }  
    }

    public void DisappearGeyser()
    {
        Destroy(this.gameObject);
    }
}

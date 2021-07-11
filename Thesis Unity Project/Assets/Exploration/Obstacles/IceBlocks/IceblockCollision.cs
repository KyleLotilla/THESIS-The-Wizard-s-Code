using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceblockCollision : MonoBehaviour
{
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private GameObject oneShotAudioPrefab;
    /*
    [SerializeField]
    private ScoreGiver scoreGiver;
    */

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetBool("melting", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Fire")
            {
                animator.SetBool("melting", true);
                //scoreGiver.GiveScore();
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
            /*
            else
            {
                scoreGiver.PenalizeScore();
            }
            */
            
        }  
    }

    public void OnMeltFinish()
    {
        Destroy(this.gameObject);
    }
}

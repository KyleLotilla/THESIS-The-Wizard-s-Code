using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudioClip : MonoBehaviour
{
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

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(this.gameObject, clip.length);
    }
}

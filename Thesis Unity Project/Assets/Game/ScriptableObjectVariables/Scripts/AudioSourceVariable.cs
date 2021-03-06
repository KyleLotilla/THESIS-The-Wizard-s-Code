using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    [CreateAssetMenu(menuName = "AudioSourceVariable")]
    public class AudioSourceVariable : ScriptableObject
    {
        [SerializeField]
        private AudioSource currentValue;
        public AudioSource Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        private void OnEnable()
        {
            currentValue = null;
        }

        public void PlayOneShot(AudioClip clip)
        {
            currentValue.PlayOneShot(clip);
        }

        public void Play(AudioClip clip)
        {
            currentValue.Stop();
            currentValue.clip = clip;
            currentValue.Play();
        }

        public void Play()
        {
            currentValue.Play();
        }
    }
}


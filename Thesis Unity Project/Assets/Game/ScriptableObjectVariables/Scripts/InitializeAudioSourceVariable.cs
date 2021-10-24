using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    public class InitializeAudioSourceVariable : MonoBehaviour
    {
        [SerializeField]
        private AudioSourceVariable audioSourceVariable;
        [SerializeField]
        private AudioSource audioSource;

        private void Start()
        {
            audioSourceVariable.Value = audioSource;
        }
    }
}


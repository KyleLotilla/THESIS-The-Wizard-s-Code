using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.WizardCode.Save;

namespace DLSU.WizardCode.Initialization
{
    public class InitializeGame : MonoBehaviour
    {
        [SerializeField]
        private SaveReader saveReader;
        [SerializeField]
        private SaveWriter saveWriter;
        [SerializeField]
        private UnityEvent onSaveFileRead;
        [SerializeField]
        private UnityEvent onSaveFileCreated;
        [SerializeField]
        private UnityEvent onSaveFileImported;

        private void Start()
        {
            if (saveReader.ReadSaveFile())
            {
                onSaveFileRead?.Invoke();
            }
            else
            {
                string previousVersion = saveReader.ImportPreviousFile();
                if (!previousVersion.Equals("0.0"))
                {
                    onSaveFileImported?.Invoke();
                }
                else
                {
                    saveWriter.CreateFile();
                    saveReader.ReadSaveFile();
                    onSaveFileCreated?.Invoke();
                }
            }

        }
    }

}

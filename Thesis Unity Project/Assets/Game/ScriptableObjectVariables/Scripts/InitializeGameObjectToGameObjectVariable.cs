using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.ScriptableObjectVariables
{
    public class InitializeGameObjectToGameObjectVariable : MonoBehaviour
    {
        [SerializeField]
        private GameObjectVariable gameObjectVariable;

        // Start is called before the first frame update
        void Start()
        {
            gameObjectVariable.Value = this.gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


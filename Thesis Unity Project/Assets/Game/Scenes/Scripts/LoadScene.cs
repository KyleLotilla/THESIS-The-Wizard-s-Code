using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.Scenes
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField]
        private StringVariable sceneName;
        public void Load()
        {
            SceneManager.LoadScene(sceneName.Value);
        }
    }

}

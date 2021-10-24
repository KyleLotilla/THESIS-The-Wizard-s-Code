using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Tags
{
    [CreateAssetMenu(menuName = "Tag")]
    public class Tag : ScriptableObject
    {
        [SerializeField]
        private string tagName;
        public string TagName
        {
            get
            {
                return tagName;
            }
        }
    }

}

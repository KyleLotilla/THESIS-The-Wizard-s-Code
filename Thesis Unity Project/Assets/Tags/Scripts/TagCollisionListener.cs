using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Events;

namespace DLSU.WizardCode.Tags
{
    public class TagCollisionListener : MonoBehaviour
    {
        [SerializeField]
        private Tag tag;
        public Tag Tag
        {
            get
            {
                return tag;
            }
        }
        [SerializeField]
        private UnityEventOneGameObjectParam response;

        public void OnTagCollision(GameObject collision)
        {
            response?.Invoke(collision);
        }
    }

}

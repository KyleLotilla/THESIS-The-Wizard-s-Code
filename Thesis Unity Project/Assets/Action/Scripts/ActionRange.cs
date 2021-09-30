using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class ActionRange : MonoBehaviour
    {
        [SerializeField]
        private Vector2 offset;
        public Vector2 Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }

        [SerializeField]
        private Vector2 maxRange;
        public Vector2 MaxRange
        {
            get
            {
                return maxRange;
            }
            set
            {
                maxRange = value;
            }
        }
    }

}

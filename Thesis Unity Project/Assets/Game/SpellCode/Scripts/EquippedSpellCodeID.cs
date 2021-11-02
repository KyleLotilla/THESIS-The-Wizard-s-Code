using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.SpellCodes
{
    public class EquippedSpellCodeID : MonoBehaviour
    {
        [SerializeField]
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }

}

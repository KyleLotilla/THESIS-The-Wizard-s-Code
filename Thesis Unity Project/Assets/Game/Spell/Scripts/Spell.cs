using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells
{

    [CreateAssetMenu(menuName = "Spell/Spell")]
    public class Spell : ScriptableObject
    {
        [SerializeField]
        private int spellID = -1;
        public int SpellID
        {
            get
            {
                return spellID;
            }
            set
            {
                spellID = value;
            }
        }
        [SerializeField]
        private string spellName;
        public string SpellName
        {
            get
            {
                return spellName;
            }
            set
            {
                spellName = value;
            }
        }
        [SerializeField]
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        [SerializeField]
        private Sprite maleIcon;
        public Sprite MaleIcon
        {
            get
            {
                return maleIcon;
            }
            set
            {
                maleIcon = value;
            }
        }
        [SerializeField]
        private Sprite femaleIcon;
        public Sprite FemaleIcon
        {
            get
            {
                return femaleIcon;
            }
            set
            {
                femaleIcon = value;
            }
        }
        [SerializeField]
        private GameObject actionPrefab;

        public GameObject ActionPrefab
        {
            get
            {
                return actionPrefab;
            }
            set
            {
                actionPrefab = value;
            }
        }
    }
}


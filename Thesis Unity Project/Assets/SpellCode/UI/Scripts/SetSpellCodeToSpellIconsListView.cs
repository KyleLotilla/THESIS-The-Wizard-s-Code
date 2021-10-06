﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.ListViews;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI
{
    public class SetSpellCodeToSpellIconsListView : MonoBehaviour
    {
        [SerializeField]
        private ListView spellIconsListView;
        [SerializeField]
        private IntVariable maxSpellCodeSpells;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnSpellCodeChanged(SpellCode spellCode)
        {
            if (spellCode != null)
            {
                List<object> spellInstanceOfSpellCode = spellCode.Select(x => (object) x).ToList();
                spellIconsListView.CreateList(spellInstanceOfSpellCode, maxSpellCodeSpells.Value);
            }
            else
            {
                spellIconsListView.Clear();
            }
        }
    }

}

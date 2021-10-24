using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI
{
    public class SetSpellInstancesOfSpellCodeToListView : MonoBehaviour
    {
        [SerializeField]
        private ListView listView;
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

        public void SetSpellInstancesOfSpellCode(SpellCode spellCode)
        {
            if (spellCode != null)
            {
                List<object> spellInstancesOfSpellCode = spellCode.Select(x => (object) x).ToList();
                listView.CreateList(spellInstancesOfSpellCode, maxSpellCodeSpells.Value);
            }
            else
            {
                listView.Clear();
            }
        }
    }

}

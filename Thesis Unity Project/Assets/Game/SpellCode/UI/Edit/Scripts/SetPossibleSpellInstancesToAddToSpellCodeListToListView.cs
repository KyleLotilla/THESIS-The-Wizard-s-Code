using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.UI.Views;
using DLSU.WizardCode.ScriptableObjectVariables;

namespace DLSU.WizardCode.SpellCodes.UI.Edit
{
    public class SetPossibleSpellInstancesToAddToSpellCodeListToListView : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceListVariable possibleSpellInstancesToAddToSpellCodeList;
        [SerializeField]
        private ListView listView;

        public void SetPossibleSpellInstancesToAddToSpellCodeList()
        {
            List<object> convertedObjectList = possibleSpellInstancesToAddToSpellCodeList.Value.Select(x => (object)x).ToList();
            listView.CreateList(convertedObjectList);
        }
    }
}


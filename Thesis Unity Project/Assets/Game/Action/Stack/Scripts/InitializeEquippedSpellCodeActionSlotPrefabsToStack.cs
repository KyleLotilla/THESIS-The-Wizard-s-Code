using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.SpellCodes;
using DLSU.WizardCode.Actions.UI;

namespace DLSU.WizardCode.Actions.Stack
{
    public class InitializeEquippedSpellCodeActionSlotPrefabsToStack : MonoBehaviour
    {
        [SerializeField]
        private bool initializeOnStart = true;
        [SerializeField]
        private SpellCodeInventory spellCodeInventory;
        [SerializeField]
        private ActionSlotPrefabsPool actionSlotPrefabsPool;
        [SerializeField]
        private ActionStack actionStack;
        // Start is called before the first frame update
        void Start()
        {
            if (initializeOnStart)
            {
                Initialize();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize()
        {
            List<GameObject> actionSlotPrefabs = actionSlotPrefabsPool.GetActionSlotPrefabs(spellCodeInventory.EquippedSpellCodes);
            actionStack.AddActionPrefabsToStack(ActionType.SPELL_CODE, actionSlotPrefabs);
        }
    }

}

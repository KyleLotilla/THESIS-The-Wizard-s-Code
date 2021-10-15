using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.Actions.UI;

namespace DLSU.WizardCode.Actions.Stack
{
    public class InitializeEquippedSpellActionSlotPrefabsToStack : MonoBehaviour
    {
        [SerializeField]
        private bool initializeOnStart = true;
        [SerializeField]
        private SpellInventory spellInventory;
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
            List<GameObject> actionSlotPrefabs = actionSlotPrefabsPool.GetActionSlotPrefabs(spellInventory.EquippedSpellInstances);
            actionStack.AddActionPrefabsToStack(ActionType.SPELL, actionSlotPrefabs);
        }
    }

}

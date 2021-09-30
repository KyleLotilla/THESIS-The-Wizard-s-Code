using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.WizardCode.Spells;
using DLSU.WizardCode.Actions.Slots;

namespace DLSU.WizardCode.Actions.Stack
{
    public class InitializeMovementActionSlotPrefabsToStack : MonoBehaviour
    {
        [SerializeField]
        private bool initializeOnStart = true;
        [SerializeField]
        private List<Spell> movementSpells;
        [SerializeField]
        private SpellDatabase spellDatabase;
        [SerializeField]
        private ActionSlotPrefabsPool actionSlotPrefabsPool;
        [SerializeField]
        private ActionStack actionStack;

        void Start()
        {
            if (initializeOnStart)
            {
                Initialize();
            }
        }

        void Update()
        {

        }

        public void Initialize()
        {
            List<SpellInstance> spellInstances = spellDatabase.GetSpellInstances(movementSpells);
            List<GameObject> actionSlotPrefabs = actionSlotPrefabsPool.GetActionSlotPrefabs(spellInstances);
            actionStack.AddActionPrefabsToStack(ActionType.MOVEMENT, actionSlotPrefabs);
        }
    }
}


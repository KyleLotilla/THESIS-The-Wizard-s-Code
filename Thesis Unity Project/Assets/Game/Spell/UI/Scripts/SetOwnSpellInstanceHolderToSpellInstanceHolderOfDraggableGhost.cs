using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Spells.UI
{
    public class SetOwnSpellInstanceHolderToSpellInstanceHolderOfDraggableGhost : MonoBehaviour
    {
        [SerializeField]
        private SpellInstanceHolder spellInstanceHolder;

        public void OnGhostCreated(GameObject currentGhost)
        {
            SpellInstanceHolder spellInstanceHolderOfGhost = currentGhost.GetComponent<SpellInstanceHolder>();
            if (spellInstanceHolderOfGhost != null)
            {
                spellInstanceHolderOfGhost.SpellInstance = spellInstanceHolder.SpellInstance;
            }
        }
    }

}

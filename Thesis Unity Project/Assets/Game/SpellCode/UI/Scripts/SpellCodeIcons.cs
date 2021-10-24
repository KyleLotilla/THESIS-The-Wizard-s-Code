using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLSU.WizardCode.SpellCodes.UI
{
    [CreateAssetMenu(menuName = "SpellCode/SpellCode Icons")]
    public class SpellCodeIcons : ScriptableObject
    {
        [SerializeField]
        private List<Sprite> icons;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Sprite GetIcon(int index)
        {
            Debug.Assert(index >= 0 && index < icons.Count, name + ": Icon Index not found");
            if (index >= 0 && index < icons.Count)
            {
                return icons[index];
            }
            else
            {
                return null;
            }
        }
    }
}


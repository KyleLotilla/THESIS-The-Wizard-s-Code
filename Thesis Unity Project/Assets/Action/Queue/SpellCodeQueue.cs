using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCodeQueue : MonoBehaviour
{
    [SerializeField]
    private SpellCodePanel spellCodePanel;
    [SerializeField]
    private SpellCodeSpellMenu spellCodeSpellMenu;
    [SerializeField]
    private List<SpaceHiglighter> spaces;
    [SerializeField]
    private SpellCodeAction _spellCodeAction;
    public SpellCodeAction spellCodeAction
    {
        private get
        {
            return _spellCodeAction;
        }
        set
        {
            _spellCodeAction = value;
            spaces.Clear();
            spellCodePanel.spellCode = spellCodeAction.spellCode;
            foreach (GameObject spaceObject in spellCodeSpellMenu.spaces)
            {
                SpaceHiglighter space = spaceObject.GetComponent<SpaceHiglighter>();
                if (space != null)
                {
                    spaces.Add(space);
                }
            }
            spellCodeAction.OnSingleActionExecutionStart += OnSequenceActionExecutionStart;
            spellCodeAction.OnSingleActionExecutionEnd += OnSequenceActionExecutionEnd;
        }
    }

    private void OnSequenceActionExecutionStart(int actionIndex)
    {
        spaces[actionIndex].HighlightSpace();
    }

    private void OnSequenceActionExecutionEnd(int actionIndex)
    {
        spaces[actionIndex].UnhighlightSpace();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

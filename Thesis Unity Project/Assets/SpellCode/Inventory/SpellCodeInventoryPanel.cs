using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnSpellCodePanelSelected(SpellCodeInventoryPanel source, SpellCode spellCode);

public class SpellCodeInventoryPanel : MonoBehaviour
{
    public event OnSpellCodePanelSelected OnSpellCodePanelSelected;
    public SpellCode spellCode { get; set; }
    [SerializeField]
    private Image image;
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color selectedColor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSpellCode()
    {
        image.color = selectedColor;
        OnSpellCodePanelSelected?.Invoke(this, spellCode);
    }

    public void UnselectSpellCode()
    {
        image.color = normalColor;
    }

    private void OnDestroy()
    {
        OnSpellCodePanelSelected = null;
    }
}

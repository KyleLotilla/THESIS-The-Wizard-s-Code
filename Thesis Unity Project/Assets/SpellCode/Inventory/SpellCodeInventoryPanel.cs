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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSpellCode()
    {
        Color color = image.color;
        color.a = 1.0f;
        image.color = color;
        OnSpellCodePanelSelected?.Invoke(this, spellCode);
    }

    public void UnselectSpellCode()
    {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    private void OnDestroy()
    {
        OnSpellCodePanelSelected = null;
    }
}

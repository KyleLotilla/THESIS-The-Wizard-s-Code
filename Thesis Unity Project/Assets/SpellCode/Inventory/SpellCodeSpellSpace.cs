using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeSpellSpace : MonoBehaviour
{
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color highlightedColor;
    [SerializeField]
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HighlightSpace()
    {
        image.color = highlightedColor;
    }

    public void UnhighlightSpace()
    {
        image.color = normalColor;
    }
}

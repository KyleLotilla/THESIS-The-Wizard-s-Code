using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceHiglighter : MonoBehaviour
{
    [SerializeField]
    private Color normalColor = Color.white;
    [SerializeField]
    private Color highlightedColor = Color.yellow;
    [SerializeField]
    private Image spaceImage;

    public void HighlightSpace()
    {
        spaceImage.color = highlightedColor;
    }

    public void UnhighlightSpace()
    {
        spaceImage.color = normalColor;
    }
}

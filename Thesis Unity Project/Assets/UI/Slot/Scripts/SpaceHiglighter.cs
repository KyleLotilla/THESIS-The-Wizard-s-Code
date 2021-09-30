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
        spaceImage.color = highlightedColor;
    }

    public void UnhighlightSpace()
    {
        spaceImage.color = normalColor;
    }
}

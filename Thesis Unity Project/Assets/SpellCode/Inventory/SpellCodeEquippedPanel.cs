using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeEquippedPanel : MonoBehaviour
{
    [SerializeField]
    private Image iconUI;
    public Sprite icon
    {
        set
        {
            iconUI.sprite = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaterialSlot : MonoBehaviour
{
    private Material _material;
    [SerializeField]
    private Image icon;
    [SerializeField]
    public Material material
    {
        get
        {
            return _material;
        }
        set
        {
            _material = value;
            if (icon != null)
            {
                icon.sprite = _material.icon;
            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
    }
}

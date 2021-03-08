using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaterialInventorySlot : MonoBehaviour
{
    private Material _material;
    [SerializeField]
    private Image iconUI;
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
            iconUI.sprite = _material.icon;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
    }
}

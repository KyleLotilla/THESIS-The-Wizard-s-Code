﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Material Inventory")]
public class MaterialInventory : ScriptableObject, IEnumerable<Material>
{
    [SerializeField]
    private List<Material> materials;
    public int Count
    {
        get
        {
            return materials.Count;
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        if (materials != null)
        {
            materials.Clear();
        }
        else
        {
            materials = new List<Material>();
        }
    }

    public void AddMaterial(Material material)
    {
        materials.Add(material);
    }

    public Material GetItemAt(int index)
    {
        if (index < materials.Count && index > -1)
        {
            return materials[index];
        }
        else
        {
            return null;
        }
    }

    public void RemoveMaterial(Material material)
    {
        materials.Remove(material);
    }


    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)materials).GetEnumerator();
    }

    IEnumerator<Material> IEnumerable<Material>.GetEnumerator()
    {
        return ((IEnumerable<Material>)materials).GetEnumerator();
    }
}
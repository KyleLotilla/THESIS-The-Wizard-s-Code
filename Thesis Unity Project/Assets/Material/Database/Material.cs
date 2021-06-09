using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Material
{
    [SerializeField]
    public int materialID;
    [SerializeField]
    public string name;
    [SerializeField]
    public string description;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public string iconPath;
    public Guid instanceID;
}

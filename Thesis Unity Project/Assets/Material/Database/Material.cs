using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material
{
    [SerializeField]
    public int materialID { get; set; }
    [SerializeField]
    public string name { get; set; }
    [SerializeField]
    public string description { get; set; }
    [SerializeField]
    public Sprite icon { get; set; }
    [SerializeField]
    public string iconPath { get; set; }
}

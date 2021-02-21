using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    [SerializeField]
    public int spellID { get; set; }
    [SerializeField]
    public string name { get; set; }
    [SerializeField]
    public string description { get; set; }
    [SerializeField]
    public Sprite icon { get; set; }
    [SerializeField]
    public string pathToIcon { get; set; }
    [SerializeField]
    public bool isEquipped { get; set; }
}

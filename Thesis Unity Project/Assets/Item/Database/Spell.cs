using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public int spellID { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public Sprite icon { get; set; }
    public string pathToIcon { get; set; }
    public bool isEquipped { get; set; }
    public string pathToActionSlot { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeEquippedCount : MonoBehaviour
{
    /*
    [SerializeField]
    private SpellCodeInventory spellCodeInventory;
    */
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        //text.text = spellCodeInventory.equippedCount.ToString() + " / " + spellCodeInventory.maxEquipped.ToString();
    }
}

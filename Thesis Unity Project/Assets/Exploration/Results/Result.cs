using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private MaterialInventory materialInventory;
    [SerializeField]
    private MaterialPickupStorage materialPickupStorage;
    [SerializeField]
    private ResultStats resultStats;
    [SerializeField]
    private ResultUI resultUI;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinGame()
    {
        resultUI.ShowResults(resultStats, materialPickupStorage);
        foreach(Material material in materialPickupStorage)
        {
            materialInventory.AddMaterial(material);
        }
    }
}

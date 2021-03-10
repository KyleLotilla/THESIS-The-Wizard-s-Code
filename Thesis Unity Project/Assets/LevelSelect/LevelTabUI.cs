using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTabUI : MonoBehaviour
{
    [SerializeField]
    private GameObject levelSelectUI;
    [SerializeField]
    private GameObject levelUI; 
    [SerializeField]
    private GameObject levelInfoUI;
    [SerializeField]
    private GameObject equipmentUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchToLevelInfo()
    {
        if (!levelInfoUI.activeSelf)
        {
            equipmentUI.SetActive(false);
            levelInfoUI.SetActive(true);
        }
    }

    public void SwitchToEquipment()
    {
        if (!equipmentUI.activeSelf)
        {
            equipmentUI.SetActive(true);
            levelInfoUI.SetActive(false);
        }
    }

    public void CloseLevelUI()
    {
        SwitchToLevelInfo();
        levelUI.SetActive(false);
        levelSelectUI.SetActive(true);
    }
}

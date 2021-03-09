using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject infoIconPanelPrefab;
    private List<GameObject> currentPanels = new List<GameObject>();
    [SerializeField]
    private MaterialDatabase materialDatabase;
    void Awake()
    {
        if (currentPanels == null)
        {
            currentPanels = new List<GameObject>();
        }
    }

    public void ShowMaterials(List<int> materialIDs, List<int> numMaterials)
    {
        Clear();
        for (int i = 0; i < materialIDs.Count; i++)
        {
            Material material = materialDatabase.GetMaterial(materialIDs[i]);
            if (material != null)
            {
                GameObject infoIconPanelObject = Instantiate(infoIconPanelPrefab, this.transform);
                currentPanels.Add(infoIconPanelObject);
                if (infoIconPanelObject != null)
                {
                    InfoIconPanel infoIconPanel = infoIconPanelObject.GetComponent<InfoIconPanel>();
                    if (infoIconPanel != null)
                    {
                        infoIconPanel.icon.sprite = material.icon;
                        infoIconPanel.text.text = material.name + " x " + numMaterials[i];
                    }
                }
            }
        }
    }

    public void Clear()
    {
        foreach (GameObject panel in currentPanels)
        {
            DestroyImmediate(panel);
        }
        currentPanels.Clear();
    }
}

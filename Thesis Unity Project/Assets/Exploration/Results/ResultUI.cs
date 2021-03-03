using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject explorationUI;
    [SerializeField]
    private GameObject resultsUI;
    [SerializeField]
    private Text resultField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowResults(ResultStats resultStats, MaterialPickupStorage materialPickupStorage)
    {
        Dictionary<string, int> materialResults = new Dictionary<string, int>();
        foreach (Material material in materialPickupStorage)
        {
            if (materialResults.ContainsKey(material.name))
            {
                materialResults[material.name]++;
            }
            else
            {
                materialResults[material.name] = 1;
            }
        }
        resultField.text = "";
        foreach (KeyValuePair<string, int> materialResult in materialResults)
        {
            resultField.text = resultField.text + materialResult.Value + " " + materialResult.Key + "\n";
        }
        resultsUI.SetActive(true);
        resultField.gameObject.SetActive(true);
        explorationUI.SetActive(false);
    }
}

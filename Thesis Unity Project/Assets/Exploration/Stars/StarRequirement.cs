using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRequirement : MonoBehaviour
{
    [SerializeField]
    private Text TwoStarText;
    [SerializeField]
    private Text ThreeStarText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stars(int twoStars, int threeStars)
    {
        this.TwoStarText.text = "Completed in less than " + (twoStars + 1).ToString() + " moves";
        this.ThreeStarText.text = "Completed in less than " + (threeStars + 1).ToString() + " moves";
    }
}

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
        this.TwoStarText.text = "Completed the stage in " + (twoStars).ToString() + " moves or less";
        this.ThreeStarText.text = "Completed the stage in " + (threeStars).ToString() + " moves or less";
    }
}

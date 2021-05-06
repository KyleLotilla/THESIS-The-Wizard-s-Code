using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isClicked = false;

    [SerializeField]
    private Text buttonText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            Time.timeScale = 3;
            buttonText.color = Color.red;
        }
        else
        {
            Time.timeScale = 1;
            buttonText.color = Color.white;
        }
    }

    public void PlayFaster()
    {
        if (!isClicked)
        {
            isClicked = true;
        }

        else
        {
            isClicked = false;
        }
    }
}

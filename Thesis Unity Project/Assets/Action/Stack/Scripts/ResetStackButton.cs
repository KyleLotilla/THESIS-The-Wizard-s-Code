using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStackButton : MonoBehaviour
{
    /*
    [SerializeField]
    private ActionStack actionStack;
    */
    [SerializeField]
    private int maxReset;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Button button;

    public bool hasRemainingResets
    {
        get
        {
            return resetCount < maxReset;
        }
    }

    private int resetCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetStack()
    {
        if (resetCount < maxReset)
        {
            //actionStack.ResetStack();
            resetCount++;
            text.text = (maxReset - resetCount).ToString();
            if (resetCount >= maxReset)
            {
                button.interactable = false;
            }
        }
    }
}

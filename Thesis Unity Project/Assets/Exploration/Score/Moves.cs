using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour
{
    private int numMoves = 0;
    [SerializeField]
    private int twoStarReq;
    [SerializeField]
    private int threeStarReq;
    [SerializeField]
    private Text moveText;

    // Start is called before the first frame update
    void Start()
    {
        this.moveText.text = this.numMoves.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUsed()
    {
        this.numMoves = this.numMoves + 1;
        this.moveText.text = this.numMoves.ToString();
    }

    public int getStars()
    {
        if(this.numMoves <= this.threeStarReq)
        {
            return 3;
        }
        else if(this.numMoves > this.threeStarReq && this.numMoves <= this.twoStarReq)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

}

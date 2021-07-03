using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour
{
    private int numMoves = 0;
    [SerializeField]
    private int LevelID;
    [SerializeField]
    private Text moveText;
    [SerializeField]
    private LevelDatabase leveldatabase;
    private Level level;

    // Start is called before the first frame update
    void Start()
    {
        this.moveText.text = this.numMoves.ToString();
        this.level = this.leveldatabase.GetLevel(LevelID);
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
        if(this.numMoves <= this.level.threeStarRequirement)
        {
            return 3;
        }
        else if(this.numMoves > this.level.threeStarRequirement && this.numMoves <= this.level.twoStarRequirement)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

}

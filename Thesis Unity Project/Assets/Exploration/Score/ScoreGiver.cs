using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    [SerializeField]
    private ExplorationScore explorationScore;
    [SerializeField]
    private GameObject scoreVisualPrefab;
    [SerializeField]
    private int _penalty;
    [SerializeField]
    private int _amount;
    [SerializeField]
    private int minAmount;
    [SerializeField]
    private bool giveOneTime = true;
    [SerializeField]
    private Vector2 offset;
    private bool giveScore = true;
    [SerializeField]
    private GameObject ScoreVisualStarPrefab;
    

    public int amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }

    public int penalty
    {
        get
        {
            return _penalty;
        }
        set
        {
            _penalty = value;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveScore()
    {
        if (giveScore)
        {
            explorationScore.AddScore(amount);
            ShowScoreVisual(amount);
            
            if (giveOneTime)
            {
                giveScore = false;
            }
        }
    }

    public void PenalizeScore()
    {
        /*if (amount > minAmount)
        {
            amount -= penalty;
            
        }*/

        explorationScore.AddScore(-penalty);
        ShowScoreVisual(-penalty);
    }

    private void ShowScoreVisual(int score)
    {
        GameObject scoreVisualObject = Instantiate(ScoreVisualStarPrefab, this.transform.position + (Vector3)offset, Quaternion.identity);
        
        if (scoreVisualObject != null)
        {
            ScoreVisualStar scoreVisualstar = scoreVisualObject.GetComponent<ScoreVisualStar>();
            
            if (scoreVisualstar != null)
            {
                scoreVisualstar.ShowScore(score);
            }
        }
    }
}

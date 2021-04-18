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
    private Vector2 offset;

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
        explorationScore.AddScore(amount);
        GameObject scoreVisualObject = Instantiate(scoreVisualPrefab, this.transform.position + (Vector3) offset, Quaternion.identity);
        if (scoreVisualObject != null)
        {
            TextMesh textMesh = scoreVisualObject.GetComponent<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = amount.ToString();
            }
        }
    }

    public void PenalizeScore()
    {
        amount -= penalty;
        Debug.Log(amount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnExplorationScoreChanged(int score);

public class ExplorationScore : MonoBehaviour
{
    public event OnExplorationScoreChanged OnExplorationScoreChanged;

    [SerializeField]
    private int _currentScore;

    public int currentScore
    {
        get
        {
            return _currentScore;
        }
        private set
        {
            _currentScore = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        OnExplorationScoreChanged?.Invoke(currentScore);
    }
}

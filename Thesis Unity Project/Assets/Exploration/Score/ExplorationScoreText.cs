using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationScoreText : MonoBehaviour
{
    [SerializeField]
    private ExplorationScore explorationScore;
    [SerializeField]
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        explorationScore.OnExplorationScoreChanged += OnExplorationScoreChanged;
        OnExplorationScoreChanged(explorationScore.currentScore);
    }

    private void OnExplorationScoreChanged(int score)
    {
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

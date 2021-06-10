using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGaige : MonoBehaviour
{
    
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private ExplorationScore explorationScore;

    [SerializeField]
    private int TotalScore;

    [SerializeField]
    private RectTransform Maximum;

    [SerializeField]
    private RectTransform Minimum;


    // Start is called before the first frame update
    void Start()
    {
        explorationScore.OnExplorationScoreChanged += OnExplorationScoreChanged;
        OnExplorationScoreChanged(explorationScore.currentScore);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnExplorationScoreChanged(int score)
    {
        
        if(score != 0)
        {
            float percentage = 1.0f / ((float)TotalScore / score);
            float starPosition = Mathf.Lerp(this.Minimum.position.x, this.Maximum.position.x, percentage);
            float Width = Mathf.Lerp(this.Minimum.sizeDelta.x, this.Maximum.sizeDelta.x, percentage);
            

            Vector2 scaleChange = new Vector2(Width, this.rectTransform.sizeDelta.y);
            this.rectTransform.sizeDelta = scaleChange;
            Vector3 newStarPosition = new Vector3(starPosition, this.rectTransform.position.y, this.rectTransform.position.z);
            this.rectTransform.position = newStarPosition;
        }
       
    }
}

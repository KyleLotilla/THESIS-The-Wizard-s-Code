using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillStar : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private RectTransform Maximum;

    [SerializeField]
    private RectTransform Minimum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillUpStar(int score, int MaximumScore)
    {
        
            float percentage = 1.0f / ((float)MaximumScore / score);
            float starPosition = Mathf.Lerp(this.Minimum.position.x, this.Maximum.position.x, percentage);
            float Width = Mathf.Lerp(this.Minimum.sizeDelta.x, this.Maximum.sizeDelta.x, percentage);
               

            Vector2 scaleChange = new Vector2(Width, this.rectTransform.sizeDelta.y);
            this.rectTransform.sizeDelta = scaleChange;
            Vector3 newStarPosition = new Vector3(starPosition, this.rectTransform.position.y, this.rectTransform.position.z);
            this.rectTransform.position = newStarPosition;
        
    }
}

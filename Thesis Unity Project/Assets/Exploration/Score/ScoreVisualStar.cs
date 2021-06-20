using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVisualStar : MonoBehaviour
{
    [SerializeField]
    private Vector2 speed;
    [SerializeField]
    private Color penaltyColor;
    
    [SerializeField]
    private GameObject oneShotAudioPrefab;
    [SerializeField]
    private AudioClip scoreAudio;
    [SerializeField]
    private AudioClip penaltyAudio;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer equation;
    [SerializeField]
    private Sprite minus;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (Vector3)(speed * Time.deltaTime);
        
    }

    public void ShowScore(int score)
    {
        if (score != 0)
        {
            GameObject oneShotAudioObject = Instantiate(oneShotAudioPrefab);
            if (oneShotAudioObject != null)
            {
                OneShotAudioClip oneShotAudioClip = oneShotAudioObject.GetComponent<OneShotAudioClip>();
                if (oneShotAudioClip != null)
                {
                    if (score > 0)
                    {
                        oneShotAudioClip.PlayClip(scoreAudio);
                        
                    }
                    else
                    {
                        this.equation.sprite = minus;
                        this.equation.color = penaltyColor;
                        this.spriteRenderer.color = penaltyColor;
                        oneShotAudioClip.PlayClip(penaltyAudio);
                    }
                }
            }

        }

    }
}
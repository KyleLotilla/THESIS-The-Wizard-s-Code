using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObstacleCollision : MonoBehaviour
{
    [SerializeField]
    private ScoreGiver scoreGiver;
    [SerializeField]
    private string correctTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Wizard")
        {
            if (collision.tag == correctTag)
            {
                scoreGiver.GiveScore();
            }
            else
            {
                scoreGiver.PenalizeScore();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ScoreGiver scoreGiver;

    [SerializeField]
    private float flyingSpeed;

    [SerializeField]
    private Animator animator;

    RobotMovement robotmovement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Lightning")
            {
                scoreGiver.GiveScore();
                animator.SetBool("On", true);
                Destroy(col.gameObject);
            }
            else
            {
                scoreGiver.PenalizeScore();
            }
        }
    }

    public void TurnOn()
    {
        this.robotmovement = this.GetComponent<RobotMovement>();
        animator.SetBool("activate", true);
        if (animator.GetBool("activate"))
        {
            this.robotmovement.Fly(flyingSpeed);
        }
    }
}

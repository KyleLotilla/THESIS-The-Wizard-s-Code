﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCollision : MonoBehaviour
{
    // Start is called before the first frame update
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
                animator.SetBool("On", true);
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

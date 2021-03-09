using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFireCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Water")
            {
                animator.SetBool("Fading", true);
            }
            Destroy(col.gameObject);
        }
    }

    public void FinishFading()
    {
        Destroy(this.gameObject);
    }
}

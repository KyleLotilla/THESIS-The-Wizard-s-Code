using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBubbleCollision : MonoBehaviour
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
        if (col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Ice")
            {
                animator.SetBool("Disappear", true);
            }
            //Destroy(col.gameObject);
        }  
    }

    public void DisappearGeyser()
    {
        Destroy(this.gameObject);
    }
}

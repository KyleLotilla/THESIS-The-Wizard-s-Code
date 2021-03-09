using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceblockCollision : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator.SetBool("melting", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Wizard")
        {
            if (col.gameObject.tag == "Fire")
            {
                animator.SetBool("melting", true);
                //Destroy(this.gameObject);
            }
            Destroy(col.gameObject);
        }  
    }

    public void OnMeltFinish()
    {
        Destroy(this.gameObject);
    }
}

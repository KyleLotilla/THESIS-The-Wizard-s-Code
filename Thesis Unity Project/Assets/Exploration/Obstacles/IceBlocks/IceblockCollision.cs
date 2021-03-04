using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceblockCollision : MonoBehaviour
{
    // Start is called before the first frame update
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
            if (col.gameObject.tag == "Fire")
            {
                Destroy(this.gameObject);
                Destroy(col.gameObject);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }  
    }
}

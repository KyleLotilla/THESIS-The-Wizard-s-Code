using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroshockCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))
        {
            if (collision.gameObject.tag == "ElectroshockDestructible")
            {
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))
        {
            if (collision.gameObject.tag == "WaterBallDestructible")
            {
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

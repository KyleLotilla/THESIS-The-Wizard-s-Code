﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.gameObject.tag == "Player"))
        {
            if (collision.gameObject.tag == "FirebellDestructible")
            {
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}

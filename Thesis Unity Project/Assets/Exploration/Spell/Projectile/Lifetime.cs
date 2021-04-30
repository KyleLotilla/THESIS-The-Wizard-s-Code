using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField]
    private float lifetime;
    private float delta = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (this.delta >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}

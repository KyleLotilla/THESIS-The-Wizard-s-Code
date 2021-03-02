using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float FireballSpeed { get; set; }
    [SerializeField]
    private float lifetime;
    private float delta = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta >= lifetime)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Vector3 position = this.transform.position;
            position.x += this.FireballSpeed * Time.deltaTime;
            this.transform.position = position;
        }

    }
}

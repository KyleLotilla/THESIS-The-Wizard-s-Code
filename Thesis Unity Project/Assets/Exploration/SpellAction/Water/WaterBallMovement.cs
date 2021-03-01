using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallMovement : MonoBehaviour
{
    [SerializeField]
    public float WaterBallSpeed { get; set; }
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
        this.delta += Time.deltaTime;
        if (this.delta >= lifetime)
        {
            Destroy(this.gameObject);
        }

        else
        {
            Vector3 position = this.transform.position;
            position.x += this.WaterBallSpeed * Time.deltaTime;
            this.transform.position = position;
        }
    }
}

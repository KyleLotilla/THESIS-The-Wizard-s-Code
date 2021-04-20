using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVisualLifetime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    private float delta = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (delta > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}

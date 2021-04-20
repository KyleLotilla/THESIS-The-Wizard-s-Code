using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVisualMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (Vector3) (speed * Time.deltaTime);
    }
}

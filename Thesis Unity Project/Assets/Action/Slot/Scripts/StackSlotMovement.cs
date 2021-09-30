using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSlotMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody2D;
    [SerializeField]
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        rigidBody2D.velocity = velocity;
    }

    private void OnDisable()
    {
        velocity = rigidBody2D.velocity;
    }
}

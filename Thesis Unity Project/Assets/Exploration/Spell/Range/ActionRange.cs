using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRange : MonoBehaviour
{
    [SerializeField]
    private Vector2 _offset;
    public Vector2 offset
    {
        get
        {
            return _offset;
        }
        set
        {
            _offset = value;
        }
    }

    [SerializeField]
    private Vector2 _velocity;
    public Vector2 velocity
    {
        get
        {
            return _velocity;
        }
        set
        {
            _velocity = value;
        }
    }

    [SerializeField]
    private Vector2 _maxRange;
    public Vector2 maxRange
    {
        get
        {
            return _maxRange;
        }
        set
        {
            _maxRange = value;
        }
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

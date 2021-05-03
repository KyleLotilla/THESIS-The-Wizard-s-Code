using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 _projectileSpeed;
    public Vector2 projectileSpeed
    {
        get
        {
            return _projectileSpeed;
        }
        set
        {
            _projectileSpeed = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += projectileSpeed.x * Time.deltaTime;
        position.y += projectileSpeed.y * Time.deltaTime;
        transform.position = position;
    }
}

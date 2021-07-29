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

    public Vector2 maxRange
    {
        get; set;
    }

    private Vector2 currentDisplacement;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplacement = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += projectileSpeed.x * Time.deltaTime;
        position.y += projectileSpeed.y * Time.deltaTime;
        transform.position = position;

        if (maxRange.x > 0.0f || maxRange.y > 0.0f)
        {
            currentDisplacement += projectileSpeed * Time.deltaTime;
            if ((maxRange.x > 0.0f && currentDisplacement.x >= maxRange.x) || (maxRange.y > 0.0f && currentDisplacement.y >= maxRange.y))
            {
                Destroy(gameObject);
            }
        }
    }
}

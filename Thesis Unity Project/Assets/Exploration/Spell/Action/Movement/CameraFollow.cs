using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Wizard;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;
    void Start()
    {
        FollowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 cameraPosition = this.Wizard.transform.position;
        cameraPosition.x += this.xOffset;
        cameraPosition.y += this.yOffset;
        cameraPosition.z = this.zOffset;
        this.transform.position = cameraPosition;
    }
}


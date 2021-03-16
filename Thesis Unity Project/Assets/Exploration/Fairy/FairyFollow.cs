using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyFollow : MonoBehaviour
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
        Vector3 fairyPosition = this.Wizard.transform.position;
        fairyPosition.x += this.xOffset;
        fairyPosition.y += this.yOffset;
        fairyPosition.z = this.zOffset;
        this.transform.position = fairyPosition;
    }
}

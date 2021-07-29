using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private WizardMovement wizardMovement;
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        if (wizardMovement.direction == Direction.RIGHT)
        {
            if (eulerAngles.y != 0.0f)
            {
                eulerAngles.y = -180.0f;
                this.transform.Rotate(eulerAngles);
            }
        }

        else if(wizardMovement.direction == Direction.LEFT)
        {
            if (eulerAngles.y != 180.0f)
            {
                eulerAngles.y = 180.0f;
                this.transform.Rotate(eulerAngles);
            }
        }

        Vector3 fairyPosition = this.wizardMovement.gameObject.transform.position;
        fairyPosition.x += this.xOffset;
        fairyPosition.y += this.yOffset;
        fairyPosition.z = this.zOffset;
        this.transform.position = fairyPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMovement : MonoBehaviour
{
    public bool shouldWalk { get; set; }

    [SerializeField]
    private float walkingSpeed;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Vector2 srcPosition;
    private Vector2 destPosition;
    private float delta = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.shouldWalk)
        {
            this.UpdateMovement();
        }
    }

    public void WalkToDestinationTile(Vector2 destPosition)
    {
        if (!CheckForCollisionInDestinationTile(destPosition))
        {
            this.srcPosition = this.gameObject.transform.position;
            this.destPosition = destPosition;
            this.shouldWalk = true;
            this.delta = 0.0f;
            animator.SetBool("ShouldWalk", true);
            Vector2 direction = destPosition - srcPosition;

            if (direction.x < 0.0f && this.gameObject.transform.rotation.eulerAngles.y == 0.0f)
            {
                this.gameObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 180.0f);

            }
            else if (direction.x > 0.0f && this.gameObject.transform.rotation.eulerAngles.y == 180.0f)
            {
                this.gameObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), -180.0f);
            }
        }
    }

    private bool CheckForCollisionInDestinationTile(Vector2 destPosition)
    {
        boxCollider.enabled = false;
        Vector2 start = this.gameObject.transform.position;
        Vector2 direction = destPosition - start;
        float distance = Vector2.Distance(start, destPosition);
        RaycastHit2D hit = Physics2D.Raycast(start, direction, distance);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    private void UpdateMovement()
    {
        this.delta += Time.deltaTime * this.walkingSpeed;
        if (this.delta >= 1.0f)
        {
            this.delta = 1.0f;
            this.shouldWalk = false;
            animator.SetBool("ShouldWalk", false);
        }

        this.gameObject.transform.position = Vector3.Lerp(this.srcPosition, this.destPosition, delta);
    }
}

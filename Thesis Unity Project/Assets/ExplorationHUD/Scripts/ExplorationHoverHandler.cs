using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationHoverHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject wizard;

    [SerializeField]
    private SpellCodePanel spellCodePanel;

    [SerializeField]
    private bool _isHoverActive = true;

    public bool isHoverActive
    {
        get
        {
            return _isHoverActive;
        }
        set
        {
            _isHoverActive = value;
        }
    }

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private int segmentMax = 20;

    [SerializeField]
    private float segmentScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleHover(GameObject hovered)
    {
        if (isHoverActive)
        {
            //SpellCodeAction spellCodeAction = hovered.GetComponent<SpellCodeAction>();
            /*
            if (spellCodeAction != null)
            {
                spellCodePanel.spellCode = spellCodeAction.spellCode;
                spellCodePanel.gameObject.SetActive(true);
            }
            */
            //ActionSlot actionSlot = hovered.GetComponent<ActionSlot>();
            /*
            if (actionSlot != null)
            {
                
                ActionRange actionRange = actionSlot.action.gameObject.GetComponent<ActionRange>();
                if (actionRange != null)
                {
                    ShowRange(actionRange);
                }
                
            }
            */
        }
    }

    public void ClearCurrentHover()
    {
        if (isHoverActive)
        {
            spellCodePanel.gameObject.SetActive(false);
            lineRenderer.positionCount = 0;
        }
    }
    /*
    public void ShowRange(ActionRange actionRange)
    {
        
        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(wizard.transform.position + (Vector3)(actionRange.Offset));
        Vector2 segmentVelocity = actionRange.velocity * Time.deltaTime;
        Vector2 maxRange = wizard.transform.position + (Vector3)(actionRange.Offset) + (Vector3)(actionRange.MaxRange);

        if (segmentVelocity.sqrMagnitude != 0)
        {
            float segmentTime = segmentScale / segmentVelocity.magnitude;
            bool hasMaxX = true;
            bool hasMaxY = true;
            if (actionRange.MaxRange.x <= 0.0f)
            {
                hasMaxX = false;
            }
            if (actionRange.MaxRange.y <= 0.0f)
            {
                hasMaxY = false;
            }

            bool overMaxRange = false;
            for (int i = 1; i <= segmentMax && !overMaxRange; i++)
            {
                Vector3 currentVertex = vertices[i - 1] + (Vector3)segmentVelocity * segmentTime;

                if (currentVertex.x >= maxRange.x && hasMaxX)
                {
                    currentVertex.x = maxRange.x;
                    overMaxRange = true;
                }

                if (currentVertex.y >= maxRange.y && hasMaxY)
                {
                    currentVertex.y = maxRange.y;
                    overMaxRange = true;
                }

                vertices.Add(currentVertex);
            }
        }
        else
        {
            vertices.Add((Vector3)maxRange);
        }
        

        lineRenderer.positionCount = vertices.Count;
        lineRenderer.SetPositions(vertices.ToArray());
        
    }
    */
}

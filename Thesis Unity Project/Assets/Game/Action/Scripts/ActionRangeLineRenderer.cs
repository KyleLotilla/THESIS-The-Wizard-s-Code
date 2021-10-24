using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.WizardCode.Actions
{
    public class ActionRangeLineRenderer : MonoBehaviour
    {
        [SerializeField]
        private Transform origin;
        [SerializeField]
        private LineRenderer lineRenderer;
        [SerializeField]
        private int segmentMax = 20;
        [SerializeField]
        private float segmentScale = 1.0f;
        public void ShowRange(ActionRange actionRange, ActionVelocity actionVelocity)
        {

            List<Vector3> vertices = new List<Vector3>();
            Vector3 startPosition = origin.position + (Vector3)(actionRange.Offset);
            vertices.Add(startPosition);
            Vector2 segmentVelocity = actionVelocity.Velocity * Time.deltaTime;
            Vector2 endPosition = origin.position + (Vector3)(actionRange.Offset) + (Vector3)(actionRange.MaxRange);


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

            bool overEndPosition = false;
            for (int i = 1; i <= segmentMax && !overEndPosition; i++)
            {
                Vector3 currentVertex = vertices[i - 1] + (Vector3)segmentVelocity * segmentTime;
                if (currentVertex.x >= endPosition.x && hasMaxX)
                {
                    currentVertex.x = endPosition.x;
                    overEndPosition = true;
                }
                if (currentVertex.y >= endPosition.y && hasMaxY)
                {
                    currentVertex.y = endPosition.y;
                    overEndPosition = true;
                }
                vertices.Add(currentVertex);
            }

            lineRenderer.positionCount = vertices.Count;
            lineRenderer.SetPositions(vertices.ToArray());
        }

        public void ShowRange(ActionRange actionRange)
        {
            List<Vector3> vertices = new List<Vector3>();
            Vector3 startPosition = origin.position + (Vector3)(actionRange.Offset);
            vertices.Add(startPosition);
            Vector3 endPosition = origin.position + (Vector3)(actionRange.Offset) + (Vector3)(actionRange.MaxRange);
            vertices.Add(endPosition);
            lineRenderer.positionCount = vertices.Count;
            lineRenderer.SetPositions(vertices.ToArray());
        }

        public void ClearRange()
        {
            lineRenderer.positionCount = 0;
        }
    }

}

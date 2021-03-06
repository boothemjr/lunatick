
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{
    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;

    private LineRenderer lineRenderer;

    private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            SetupCircle();
        }
    
    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(transform.position.x + radius * Mathf.Cos(theta), transform.position.y + radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
    private void OnDrawGizmos() 
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        
        Vector3 oldPos = new Vector3(radius,0,0);
        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
    }

}

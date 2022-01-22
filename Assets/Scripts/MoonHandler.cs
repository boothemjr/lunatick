using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonHandler : MonoBehaviour
{
    public PhaseManager phaseManager;

    public string sortingLayer;

    public Circle circle;

    public Transform moon;
    public Transform moonShadow;

    private LineRenderer lineRenderer;

    public float theta = 0f;

    private void Update()
    {
        theta = phaseManager.cycleDay / 28 * 2 * Mathf.PI;
        PlaceAlongOrbit(theta);
    }

    // places moon along orbit based on the angle of orbit
    private void PlaceAlongOrbit(float angle)
    {
        Vector3 moonPos = new Vector3(circle.radius * Mathf.Cos(angle), circle.radius * Mathf.Sin(angle), 0f);
        float moonRadius = moon.GetComponent<SpriteRenderer>().bounds.size.x / 4;

        Vector3 shadowPos = new Vector3(circle.radius * Mathf.Cos(angle) - moonRadius, circle.radius * Mathf.Sin(angle), 0f);

        moonShadow.position = shadowPos;
        moon.position = moonPos;
    }


    // PlaceonCircle for if we want to manually select positions of the orbit
    // private Vector3 PlaceonCircle(Vector3 position)
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(position);
    //     Vector3 pos = ray.GetPoint(0f);

    //     pos = transform.InverseTransformPoint(pos);
    //     float angle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
    //     pos.x = circle.radius * Mathf.Sin(angle * Mathf.Deg2Rad);
    //     pos.y = circle.radius * Mathf.Cos(angle * Mathf.Deg2Rad);
    //     pos.z = 0f;

    //     return pos;
    // }
    
}

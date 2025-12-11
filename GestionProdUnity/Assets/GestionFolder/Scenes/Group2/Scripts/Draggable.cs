using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class Draggable : MonoBehaviour
{
    private Camera cam;
    private bool dragging;

    public SplineContainer spline;

    private float currentT;

    private void Start()
    {
        cam = Camera.main;

        // Snap sur spline au départ
        float3 nearest;
        float t;
        SplineUtility.GetNearestPoint(spline.Spline, transform.position, out nearest, out t);

        currentT = t;
        transform.position = nearest;
    }

    private void OnMouseDown()
    {
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void Update()
    {
        if (!dragging) return;

        Vector3 mouse = Input.mousePosition;

        // ⛔ FIX DU TP → on utilise la vraie distance
        mouse.z = Vector3.Distance(cam.transform.position, transform.position);

        Vector3 worldPos = cam.ScreenToWorldPoint(mouse);

        float3 wp = new float3(worldPos.x, worldPos.y, worldPos.z);

        float3 nearest;
        float t;
        SplineUtility.GetNearestPoint(spline.Spline, wp, out nearest, out t);

        currentT = t;
        transform.position = nearest;
    }
}
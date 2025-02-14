using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrackerTwo : MonoBehaviour
{
    public Vector3[] path = new Vector3[]
    {
        new Vector3(-1.5f,2.2f,1.0f),
        new Vector3(-1.433f,2.161f,2.0f),
        new Vector3(-1.367f,2.111f,3.0f),
        new Vector3(-1.300f,2.051f,4.0f),
        new Vector3(-1.233f,1.979f,5.0f),
        new Vector3(-1.167f,1.897f,6.0f),
        new Vector3(-1.100f,1.804f,7.0f),
        new Vector3(-1.033f,1.699f,8.0f),
        new Vector3(-0.967f,1.584f,9.0f),
        new Vector3(-0.900f,1.459f,10.0f),
        new Vector3(-0.833f,1.322f,11.0f),
        new Vector3(-0.767f,1.174f,12.0f),
        new Vector3(-0.700f,1.016f,13.0f),
        new Vector3(-0.633f,0.846f,14.0f),
        new Vector3(-0.567f,0.666f,15.0f),
        new Vector3(-0.500f,0.475f,16.0f),
        new Vector3(-0.433f,0.272f,17.0f),
        new Vector3(-0.367f,0.059f,18.0f),
        new Vector3(-0.300f,0.117f,19.0f),
        new Vector3(-0.233f,0.270f,20.0f),
        new Vector3(-0.167f,0.412f,21.0f),
        new Vector3(-0.100f,0.870f,22.0f),
        new Vector3(-0.033f,0.772f,23.0f),
        new Vector3(0.033f,0.772f,24.0f),
        new Vector3(0.100f,0.870f,25.0f),
        new Vector3(0.167f,0.958f,26.0f),
        new Vector3(0.233f,1.034f,27.0f),
        new Vector3(0.300f,1.100f,28.0f),
        new Vector3(0.367f,1.154f,29.0f),
        new Vector3(0.433f,1.198f,30.0f),
        new Vector3(0.500f,1.231f,31.0f),
        new Vector3(0.567f,1.253f,32.0f)
    };

    // Speed at which the ball moves
    public float speed = 40f;

    private int currentPoint = 0;

    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if we haven't reached the last point in the path
        if (currentPoint < path.Length)
        {
            // Move the ball toward the current point
            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint], speed * Time.deltaTime);

            // Check if the ball has reached the current point
            if (transform.position == path[currentPoint])
            {
                currentPoint++;
            }
        }

        UpdateLineRenderer();

    }

    // Updates the line renderer to show the path dynamically as the ball moves
    void UpdateLineRenderer()
    {
        // Check if we need to update the LineRenderer (only when ball is moving)
        if (lineRenderer != null)
        {
            // Update the line renderer to match the number of points the ball has traversed
            lineRenderer.positionCount = currentPoint + 1;

            // Set the positions of the line renderer up to the current position of the ball
            for (int i = 0; i <= currentPoint; i++)
            {
                lineRenderer.SetPosition(i, path[i]);
            }
        }
    }
}

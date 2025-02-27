using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public Vector3[] path = new Vector3[]
    {
        new Vector3(-1.5f,2.2f,1f),
        new Vector3(-1.414f,2.152f,1.9f),
        new Vector3(-1.329f,2.094f,2.8f),
        new Vector3(-1.243f,2.026f,3.7f),
        new Vector3(-1.157f,1.946f,4.6f),
        new Vector3(-1.072f,1.855f,5.5f),
        new Vector3(-0.986f,1.754f,6.4f),
        new Vector3(-0.900f,1.641f,7.3f),
        new Vector3(-0.815f,1.518f,8.2f),
        new Vector3(-0.729f,1.384f,9.1f),
        new Vector3(-0.643f,1.238f,10.0f),
        new Vector3(-0.558f,1.082f,10.9f),
        new Vector3(-0.472f,0.916f,11.8f),
        new Vector3(-0.386f,0.738f,12.7f),
        new Vector3(-0.301f,0.549f,13.6f),
        new Vector3(-0.215f,0.350f,14.5f),
        new Vector3(-0.129f,0.139f,15.4f),
        new Vector3(-0.044f,0.068f,16.3f),
        new Vector3(0.042f,0.251f,17.2f),
        new Vector3(0.128f,0.422f,18.1f),
        new Vector3(0.213f,0.582f,19.0f),
        new Vector3(0.385f,0.871f,20.8f),
        new Vector3(0.470f,0.998f,21.7f),
        new Vector3(0.556f,1.115f,22.6f),
        new Vector3(0.642f,1.221f,23.5f),
        new Vector3(0.727f,1.316f,24.4f),
        new Vector3(0.813f,1.401f,25.3f),
        new Vector3(0.899f,1.474f,26.2f),
        new Vector3(0.984f,1.536f,27.1f),
        new Vector3(1.070f,1.588f,28.0f),
        new Vector3(1.156f,1.629f,28.9f)
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

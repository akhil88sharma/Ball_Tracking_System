using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public Vector3[] path = new Vector3[]
    {
        new Vector3(-3f, 10f, 0f),
        new Vector3(-2.85f, 9.25f, 5f),
        new Vector3(-2.7f, 8.5f, 10f),
        new Vector3(-2.55f, 7.75f, 15f),
        new Vector3(-2.4f, 7f, 20f),
        new Vector3(-2.25f, 6.25f, 25f),
        new Vector3(-2.1f, 5.5f, 30f),
        new Vector3(-1.95f ,4.75f, 35f),
        new Vector3(-1.8f, 4f, 40f),
        new Vector3(-1.65f, 3.25f, 45f),
        new Vector3(-1.5f, 2.5f, 50f),
        new Vector3(-1.35f, 1.75f, 55f),
        new Vector3(-1.2f, 1f, 60f),
        new Vector3(-1.05f, 0.5f, 65f),
        new Vector3(-0.9f, 1.15f, 70f),
        new Vector3(-0.75f, 1.8f, 75f),
        new Vector3(-0.6f, 2.45f, 80f),
        new Vector3(-0.45f, 3.1f, 85f),
        new Vector3(-0.3f, 3.75f, 90f),
        new Vector3(-0.15f, 4.4f, 95f),
        new Vector3(0f, 5f, 100f)
    };

    // Speed at which the ball moves
    public float speed = 40f;

    // Camera follow speed (smoothness)
    public float cameraFollowSpeed = 30f;

    private int currentPoint = 0;

    public Camera mainCamera;

    public LineRenderer lineRenderer;

    public GameObject cam;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {

        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(path[0].x, path[0].y + 1f, path[0].z - 10f);
            mainCamera.transform.LookAt(transform.position); // Make the camera look at the ball
        }

        myAnim = cam.GetComponent<Animator>();
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

        // Smoothly follow the ball with the camera
        if (mainCamera != null)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z - 5f);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
            mainCamera.transform.LookAt(transform.position); // Keep the camera focused on the ball
        }
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

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Stump"))
        {
            myAnim.enabled = true;
        }
    }
}

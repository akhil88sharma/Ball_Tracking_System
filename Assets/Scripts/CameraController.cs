using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            CameraFront();
        }

        if (Input.GetKeyDown("2"))
        {
            CameraSide();
        }

        if (Input.GetKeyDown("3"))
        {
            CameraBack();
        }
    }

    void CameraFront()
    {
        Camera1.SetActive(true);
        Camera2.SetActive(false);
        Camera3.SetActive(false);
    }

    void CameraSide()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(true);
        Camera3.SetActive(false);
    }

    void CameraBack()
    {
        Camera1.SetActive(false);
        Camera2.SetActive(false);
        Camera3.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 50.0f;
    private const float Y_ANGLE_MAX = -80.0f;

    public Transform target;
    public float distance = 4.0f;
    public float xSensitivity = 10.0f;
    public float ySensitivity = 10.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private bool rightClicked = false;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rightClicked = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            rightClicked = false;
        }

        if (rightClicked)
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");
            currentY = Mathf.Clamp(currentY, Y_ANGLE_MAX, Y_ANGLE_MIN);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible == false)
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }
    void LateUpdate()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -1 * distance);
        Quaternion rotation = Quaternion.Euler(ySensitivity * currentY, xSensitivity * currentX, 0.0f);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}
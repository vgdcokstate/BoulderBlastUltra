using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const float Y_ANGLE_MAX = 10f;
    private const float Y_ANGLE_MIN = -12.5f;

    public Transform Target;
    public float Distance = -5.0f;
    public float X_Sensitivity = 8.0f;
    public float Y_Sensitivity = 4.0f;

    private float _currentX = 0.0f;
    private float _currentY = 0.0f;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _currentX += Input.GetAxis("Mouse X");
            _currentY += Input.GetAxis("Mouse Y");

            Debug.Log($"{_currentX}, {_currentY}");

            _currentY = Mathf.Clamp(_currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }
    }
    void LateUpdate()
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -1 * Distance);
        Quaternion rotation = Quaternion.Euler(Y_Sensitivity * _currentY, X_Sensitivity * _currentX, 0.0f);
        transform.position = Target.position + rotation * direction;
        transform.LookAt(Target.position);
    }
}
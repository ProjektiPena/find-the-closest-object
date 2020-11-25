using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 2f;
    public float sensitivity = 5f;
    public float freeLookSensitivity = 10f;
    public float scrollSpeed = 6f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //  transform.Translate(Vector3.forward * sensitivity * Time.deltaTime);
            transform.position += transform.forward * sensitivity;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //  transform.Translate(Vector3.forward * sensitivity * Time.deltaTime);
                transform.position += transform.forward * sensitivity * speed;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            // transform.Translate(-Vector3.forward * sensitivity * Time.deltaTime);
            transform.position -= transform.forward * sensitivity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * sensitivity;
            // transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * sensitivity;
            // transform.RotateAround(target.position, -target.up, speed * Time.deltaTime);
        }


        if (Input.GetMouseButton(2))
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);


        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * scrollSpeed, Space.Self);

    }
}
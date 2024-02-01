using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public float SensX;
    public float SensY;

    public Transform orientation;

    float x_Rotation;
    float Y_rotation;


    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        float Mouse_x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;

        float Mouse_Y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;
        Y_rotation += Mouse_x;
        x_Rotation -= Mouse_Y;
        x_Rotation = Mathf.Clamp(x_Rotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(x_Rotation, Y_rotation, 0);
        orientation.rotation = Quaternion.Euler(0, Y_rotation, 0);



    }
}

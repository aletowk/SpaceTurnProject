using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public float cameraSpeed;
    public float cameraRotationSpeed;
    public float speedH, speedV;
    public float scrollWheelSpeed;

    float yaw = 0f;
    float pitch = 0f;


    private void Start()
    {
        //cameraSpeed = 50f;
        //cameraRotationSpeed = 0.05f;
        //speedH = 5f;
        //speedV = 5f;

        pitch = transform.rotation.x;
        yaw = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = -Input.GetAxis("Mouse ScrollWheel")*scrollWheelSpeed;
        //float yaw = Input.GetAxisRaw("Yaw");


        //Translations
        if (Input.GetKey(KeyCode.Space))
        {
            y = 1f;
        }else if(Input.GetKey(KeyCode.Comma))
        {
            y = -1f;
        }
        if (x != 0f  || z != 0f)
        {
            Vector3 frontDir = transform.forward;
            frontDir.y = 0;
            Vector3 sideDir = transform.right;
            sideDir.y = 0;
            transform.position += (frontDir * z + sideDir * x) * cameraSpeed * Time.deltaTime;
            //transform.RotateAroundLocal(Vector3.up ,yaw*cameraRotationSpeed);
        }
        if (y != 0f)
            transform.position += Vector3.down * y * cameraSpeed * Time.deltaTime;
        

        //Rotations
        if (Input.GetMouseButton(2))
        {
            pitch -= Input.GetAxis("Mouse Y")* speedH;
            yaw += Input.GetAxis("Mouse X") * speedV;
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }else if(Input.GetKeyDown(KeyCode.A))
        {
            yaw -= speedV;
            transform.eulerAngles += new Vector3(0f, yaw, 0f);
        }else if(Input.GetKeyDown(KeyCode.E))
        {
            yaw += speedV;
            transform.eulerAngles += new Vector3(0f, yaw, 0f);
        }
    }
}

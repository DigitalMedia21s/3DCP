using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform targetTransform;
    //public Vector3 CameraOffeset;
    
    public float distance = 4f;

    public float xSpeed = 220f;
    public float ySpeed = 100f;

    private float x = 0f;
    private float y = 0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;

        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;

        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;



        //앵글값 정하기(y값 제한)

        y = ClampAngle(y, yMinLimit, yMaxLimit);



        //카메라 위치 변화 계산

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        Vector3 position = rotation * new Vector3(0, 0.9f, -distance) + targetTransform.position + new Vector3(0.0f, 0, 0.0f);



        transform.rotation = rotation;

        targetTransform.rotation = Quaternion.Euler(0, x, 0);

        transform.position = position;
    }
}

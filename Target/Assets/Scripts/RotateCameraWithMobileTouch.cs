using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraWithMobileTouch : MonoBehaviour
{
    Vector3 firstpoint; //change type on Vector3
    Vector3 secondpoint;
    float xAngle ; //angle for axes x for rotation
    float yAngle;
    float xAngTemp;//temp variable for angle
    float yAngTemp;
    void Start()
    {
        //Initialization our angles of camera
        xAngle = 0f;
        yAngle = 0f;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f);
    }
    void Update()
    {
        //Check count touches
        if (Input.touchCount > 0)
        {
            //Touch began, save position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180 / Screen.width;
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90/ Screen.height;
                //Rotate camera
                yAngle = Mathf.Clamp(yAngle, -80f, 80f);
                this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0f);
            }
        }
    }
}

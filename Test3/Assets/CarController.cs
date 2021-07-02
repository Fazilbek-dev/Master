using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public GameObject WheelRight;
    public GameObject WheelLeft;
    //public GameObject WheelR;
    //public GameObject WheelL;
    public bool BackWheels;
    public bool BackFront;
    public int WheelRotateAngle = 2;

    public Joystick joystick;


    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {

        float motor = maxMotorTorque * joystick.Vertical;
        float steering = maxSteeringAngle * joystick.Horizontal;


        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        if (Input.GetKeyDown("a"))
        {
            if (BackWheels)
            {
                //transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
        }
        if (Input.GetKeyUp("a"))
        {
            if (BackWheels)
            {
                
                WheelRight.transform.Rotate(0, 0, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, 0, 0);
                WheelLeft.transform.Rotate(0, 0, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (BackWheels)
            {
                //transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, WheelRotateAngle + 10, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, WheelRotateAngle + 10, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
        }
        if (Input.GetKeyUp("d"))
        {
            if (BackWheels)
            {
                
                WheelRight.transform.Rotate(0, 0, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, 0, 0);
                WheelLeft.transform.Rotate(0, 0, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
        }
    }
}
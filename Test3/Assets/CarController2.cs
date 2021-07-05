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

public class CarController2 : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float speed;
    public float maxSteeringAngle;
    public Transform mePos;
    public Transform[] checkPoints;
    public GameObject WheelRight;
    public GameObject WheelLeft;
    //public GameObject WheelR;
    //public GameObject WheelL;
    public bool BackWheels;
    public bool BackFront;
    public int WheelRotateAngle = 2;
    public float MaxDistance = 2;

    public int i = 0;


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

    public void Update()
    {

        if (MaxDistance > Vector3.Distance(transform.position, checkPoints[i].position))
        {// если MaxDistance больше дистанции до цели
            i++;
        }
        if(i >= checkPoints.Length)
        {
            i = 0;
        }
        
        var rotateNeed = Quaternion.LookRotation(checkPoints[i].transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateNeed,10f * Time.deltaTime);


        float motor = maxMotorTorque;

        float steering = maxSteeringAngle * (speed + 0.7f);

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
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class AxleInfob
{
    public WheelCollider leftWheells;
    public WheelCollider rightWheells;
    public bool motorr;
    public bool steeringg;
}

public class CarController1 : MonoBehaviour
{
    public List<AxleInfob> axleInfob;
    public float maxMotorTorquee;
    public float speed;
    public float maxSteeringAnglee;
    public Transform mePos;
    public Transform[] checkPoint;
    public GameObject WheelRightt;
    public GameObject WheelLeftt;
    //public GameObject WheelR;
    //public GameObject WheelL;
    public bool BackWheel;
    public bool BackFront;
    public int WheelRotateAnglee = 2;
    public float MaxDistance = 2;
    private Rigidbody rb;

    public GameObject joystickk;
    public int i = 0;


    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisual(WheelCollider collider)
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

        
        float motor = maxMotorTorquee * 1;
        float steering = maxSteeringAnglee * -joystickk.transform.rotation.z;


        

        foreach (AxleInfob axleInfoo in axleInfob)
        {
            if (axleInfoo.steeringg)
            {
                axleInfoo.leftWheells.steerAngle = steering;
                axleInfoo.rightWheells.steerAngle = steering;
            }
            if (axleInfoo.motorr)
            {
                axleInfoo.leftWheells.motorTorque = motor;
                axleInfoo.rightWheells.motorTorque = motor;
            }
            ApplyLocalPositionToVisual(axleInfoo.leftWheells);
            ApplyLocalPositionToVisual(axleInfoo.rightWheells);
        }

        if (Input.GetKeyDown("a"))
        {
            if (BackWheel)
            {
                //transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
                WheelRightt.transform.Rotate(0, -WheelRotateAnglee, 0);
                WheelLeftt.transform.Rotate(0, -WheelRotateAnglee, 0);
            }
            else
            {
                WheelRightt.transform.Rotate(0, -WheelRotateAnglee, 0);
                WheelLeftt.transform.Rotate(0, -WheelRotateAnglee, 0);
            }
        }
        if (Input.GetKeyUp("a"))
        {
            if (BackWheel)
            {
                
                WheelRightt.transform.Rotate(0, 0, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, 0, 0);
                WheelLeftt.transform.Rotate(0, 0, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                WheelRightt.transform.Rotate(0, -WheelRotateAnglee, 0);
                WheelLeftt.transform.Rotate(0, -WheelRotateAnglee, 0);
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (BackWheel)
            {
                //transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
                WheelRightt.transform.Rotate(0, WheelRotateAnglee, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, WheelRotateAngle + 10, 0);
                WheelLeftt.transform.Rotate(0, WheelRotateAnglee, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, WheelRotateAngle + 10, 0);
            }
            else
            {
                WheelRightt.transform.Rotate(0, WheelRotateAnglee, 0);
                WheelLeftt.transform.Rotate(0, WheelRotateAnglee, 0);
            }
        }
        if (Input.GetKeyUp("d"))
        {
            if (BackWheel)
            {
                
                WheelRightt.transform.Rotate(0, 0, 0);
                //WheelR.transform.eulerAngles = new Vector3(0, 0, 0);
                WheelLeftt.transform.Rotate(0, 0, 0);
                //WheelL.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                WheelRightt.transform.Rotate(0, WheelRotateAnglee, 0);
                WheelLeftt.transform.Rotate(0, WheelRotateAnglee, 0);
            }
        }
    }
}
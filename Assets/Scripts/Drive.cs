using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Drive : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public GameObject WheelFL;
    public GameObject WheelFR;
    public GameObject WheelRL;
    public GameObject WheelRR;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        //Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        //visualWheel.transform.position = position;
        //visualWheel.transform.rotation = rotation;

        // as we move collider, we want to reposition the mesh
        WheelFL.transform.position = position;
        WheelFL.transform.rotation = rotation;

        WheelFR.transform.position = position;
        WheelFR.transform.rotation = rotation;

        WheelRL.transform.position = position;
        WheelRL.transform.rotation = rotation;

        WheelRR.transform.position = position;
        WheelRR.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

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
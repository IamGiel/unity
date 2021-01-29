using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTubeWheelCollider : MonoBehaviour
{
    public WheelCollider WC;
    public float torque = 200.0f;
    public GameObject Wheel;

    // max steering
    public float maxSteerAngle = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }

    void go(float accel, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        float thrustforTorque = accel * torque;
        WC.motorTorque = thrustforTorque;
        WC.steerAngle = steer;

        // align wheel mesh with wheelCollider so that it turns
        Quaternion quat;
        Vector3 position;

        

        // as we move collider, we want to reposition the mesh
        WC.GetWorldPose(out position, out quat);
        Wheel.transform.position = position;
        Wheel.transform.rotation = quat;
    }
    // Update is called once per frame
    void Update()
    {
        float a = Input.GetAxis("Vertical"); // acceleration
        float s = Input.GetAxis("Horizontal"); // acceleration
        go(a,s);
    }
}

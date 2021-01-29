using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Rigidbody))]
public class SampleWheelScript : MonoBehaviour
{
    public List<Transform> WheelsThatSteer;
    public List<Transform> WheelsWithoutSteer;
    private Dictionary<Transform, WheelCollider> _wheelsThatSteer = new Dictionary<Transform, WheelCollider>();
    private Dictionary<Transform, WheelCollider> _wheelsWithoutSteer = new Dictionary<Transform, WheelCollider>();
    [Tooltip("Motor torque on the wheel axle expressed in Newton meters.")]
    private float maxTorque = 60.0f;
    private float maxSteeringAngle = 30;
    public float suspension;
    public float radius_;

    void Start()
    {
        foreach (var wheel in WheelsThatSteer)
        {
            _wheelsThatSteer.Add(wheel, addWheelCollider(wheel));
        }
        foreach (var wheel in WheelsWithoutSteer)
        {
            _wheelsWithoutSteer.Add(wheel, addWheelCollider(wheel));
        }
    }
    void Update()
    {
        foreach (var wheel in _wheelsThatSteer)
        {
            // steer mesh
            wheel.Key.localEulerAngles = new Vector3(
                wheel.Key.localEulerAngles.x,
                wheel.Value.steerAngle - wheel.Key.localEulerAngles.z,
                wheel.Key.localEulerAngles.z);
            // rotate mesh
            wheel.Key.Rotate(wheel.Value.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        }
        foreach (var wheel in _wheelsWithoutSteer)
        {
            // rotate mesh
            wheel.Key.Rotate(wheel.Value.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        }
    }
    void FixedUpdate()
    {
        var torque = Input.GetAxis("Vertical") * maxTorque;
        var steerAngle = Input.GetAxis("Horizontal") * maxSteeringAngle;
        // update wheel collider physics
        foreach (var wheel in _wheelsThatSteer.Values)
        {
            wheel.motorTorque = torque;
            wheel.steerAngle = steerAngle;
        }
        foreach (var wheel in _wheelsWithoutSteer.Values)
        {
            wheel.motorTorque = torque;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var wheel in _wheelsWithoutSteer.Values)
            {
                wheel.motorTorque = 0f;
            }
        }
    }
    private WheelCollider addWheelCollider(Transform wheelMesh)
    {
        var go = new GameObject(wheelMesh.name + "GelsCollider");
        go.transform.position = wheelMesh.position;
        go.transform.parent = wheelMesh.parent;
        go.transform.rotation = wheelMesh.rotation;
        //var wheelRadius = 0.85f;
        
        var wc = go.AddComponent<WheelCollider>();
        wc.radius = 0.85f;
        wc.suspensionDistance = 0f;
        return wc;
    }
}
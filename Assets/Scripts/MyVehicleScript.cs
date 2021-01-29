using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVehicleScript : MonoBehaviour

{

    //private float thrust = 10.0f;
    public Rigidbody rb;
    public float moveSpeed;
    private float dirx, dirz;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // move vehicle
        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward);
        dirx = Input.GetAxis("Horizontal") * moveSpeed;
        dirz = Input.GetAxis("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(dirx, rb.velocity.y, dirz);

        // AWSD multi directional keys
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.Self); //LEFT
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self); //RIGHT
        //}
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self); //LEFT
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.Self); //RIGHT
        }

        // rotate left and right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, .5f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -.5f, 0);
        }
    }
}

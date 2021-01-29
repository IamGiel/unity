using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float forwardInput;
    public float maxSteerAngle = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(new Vector3(1, 0, 0), verticalInput);
        // tilt the plane left/right based on left/right arrow keys
        transform.Rotate(new Vector3(0, 1, 0), forwardInput);

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("YO A is typed! ");
            // tilt the plane left/right based on left/right arrow keys
            transform.Rotate(new Vector3(0, 0, 1), rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("YO A is typed! ");
            // tilt the plane left/right based on left/right arrow keys
            transform.Rotate(new Vector3(0, 0, -1), rotationSpeed);
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    //Rotate the sprite about the Y axis in the positive direction
        //    transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * m_Speed, Space.World);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    //Rotate the sprite about the Y axis in the negative direction
        //    transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * m_Speed, Space.World);
        //}

    }
}

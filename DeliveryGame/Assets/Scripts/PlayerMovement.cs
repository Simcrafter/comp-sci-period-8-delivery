        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;

public class PlayerMovement : MonoBehaviour
{
    public float acc = 15f;
    public float jumpPower = 300f;
    public float CofKinFric = 1f;
    private Rigidbody rb;

    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement();
        Jump();
        Debug.Log(rb.velocity);
    }

    void movement()
    {
        if (Input.GetKey("w"))
        {
            //transform.position += transform.forward * acc * Time.deltaTime;
            rb.AddForce(transform.forward * acc);
        }
        if (Input.GetKey("s"))
        {
            //transform.position -= transform.forward * acc * Time.deltaTime;
            rb.AddForce(-transform.forward * acc);
        }
        if (Input.GetKey("a"))
        {
            //transform.position -= transform.right * acc * Time.deltaTime;
            rb.AddForce(-transform.right * acc);
        }
        if (Input.GetKey("d"))
        {
            //transform.position += transform.right * acc * Time.deltaTime;
            rb.AddForce(transform.right * acc);
        }

        //im trying to code friction cus i dumb
        if((Mathf.Abs(rb.velocity.x) > 0f || Mathf.Abs(rb.velocity.z) > 0f)&&(!Input.GetKey("w") || !Input.GetKey("s") || !Input.GetKey("d") || !Input.GetKey("a")))
        {
            rb.AddForce(CofKinFric * rb.mass * -Mathf.Sign(rb.velocity.x) * transform.right);
            rb.AddForce(CofKinFric * rb.mass * -Mathf.Sign(rb.velocity.z) * transform.forward);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
}

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
    public float maxvelocity=15f;

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
        if (Input.GetKey("w") && rb.velocity.magnitude < maxvelocity)
        {
            //transform.position += transform.forward * acc * Time.deltaTime;
            rb.AddForce(transform.forward * acc);
        }
        if (Input.GetKey("s") && rb.velocity.magnitude < maxvelocity)
        {
            //transform.position -= transform.forward * acc * Time.deltaTime;
            rb.AddForce(-transform.forward * acc);
        }
        if (Input.GetKey("a") && rb.velocity.magnitude < maxvelocity)
        {
            //transform.position -= transform.right * acc * Time.deltaTime;
            rb.AddForce(-transform.right * acc);
        }
        if (Input.GetKey("d") && rb.velocity.magnitude < maxvelocity)
        {
            //transform.position += transform.right * acc * Time.deltaTime;
            rb.AddForce(transform.right * acc);
        }

        //im trying to code friction cus i dumb
        if((Mathf.Abs(rb.velocity.x) > 0f || Mathf.Abs(rb.velocity.z) > 0f)&&(!Input.GetKey("w") || !Input.GetKey("s")))
        {
            rb.AddForce(CofKinFric * rb.mass * -Mathf.Sign(rb.velocity.z) * Vector3.forward);
        }
        if ((Mathf.Abs(rb.velocity.x) > 0f || Mathf.Abs(rb.velocity.z) > 0f) && (!Input.GetKey("d") || !Input.GetKey("a")))
        {
            rb.AddForce(CofKinFric * rb.mass * -Mathf.Sign(rb.velocity.x) * Vector3.right);
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

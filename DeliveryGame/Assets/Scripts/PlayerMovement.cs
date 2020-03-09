using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    float jumpPower;

    void Update()
    {
        movement();
        Jump();
    }

    void movement()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    
    

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Jump");
            if (GetComponentInChildren<GroundedCheck>().grounded == true)
            {
                
                GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            }
        }
    }
}


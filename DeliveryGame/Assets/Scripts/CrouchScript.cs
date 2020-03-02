using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{

    private bool isCrouched;
    public Vector3 crouchedVector3Scale;
    public Vector3 defaultVector3Scale;
    public float crouchSpeed;


    void Start()
    {
        isCrouched = false;
        crouchedVector3Scale = new Vector3(1,.5f, 1);
        defaultVector3Scale = new Vector3(1, 1, 1);
    }

    
    void Update()
    {
        //first sees if the player has pressed the crouch key, then changes the bool accordingly 
        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("crouched");
            if (isCrouched == true) isCrouched = false;
            else isCrouched = true;
        }
        //sees whether the crouching bool is true or false and runs the function that will change its hight
        if (isCrouched == true) Crouch();
        else StandUp();
         
    }
    //functions see if the current scale matches the wanted scale and changes the scale and hight to match over time
    public void Crouch()
    {
       
        if(transform.localScale.y > crouchedVector3Scale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - crouchSpeed * Time.deltaTime, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y - crouchSpeed * Time.deltaTime, transform.position.z);
        }
        //moves the player down so crouching does not cause the player to temperarily fall
        //transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
    }

    public void StandUp()
    {
        if (transform.localScale.y < defaultVector3Scale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crouchSpeed * Time.deltaTime, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + crouchSpeed * Time.deltaTime, transform.position.z);
        }
    }
}

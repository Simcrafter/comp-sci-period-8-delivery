using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public bool grounded;
    //distancetoground is how far the ground needs to be to be registered as touching 
    float distanceToGround;
    


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit,1.1f))
        {
            grounded = true;
            Debug.Log("grounded");

        }
        else
        {
            grounded = false;
            Debug.Log("not grounded");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float sensitivity;
    public GameObject Head;
    private float mouseDirectionX;
    private float mouseDirectionY;
    
    // Start is called before the first frame update
    void Start()
    {
        //disables the body renderer while  game is running
        GetComponent<MeshRenderer>().enabled = false;
        Head.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMouseMovement();
    }

    void PlayerMouseMovement()
    {

        mouseDirectionX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseDirectionY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //caps the mouse direction if the player looks too far up or down
        if (mouseDirectionY > 85) mouseDirectionY = 85;
        else if (mouseDirectionY < -85) mouseDirectionY = -85;

        //Changes whole body on the X axis, while only the head moves on the Y axis

        transform.localRotation = Quaternion.Euler(new Vector3(0f, mouseDirectionX, 0f));
        Head.transform.localRotation = Quaternion.Euler(new Vector3(mouseDirectionY, 0f, 0f));

    }
}

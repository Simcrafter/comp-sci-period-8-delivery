using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public bool win = false;
    public bool start = false;
    public bool go = false;
    public Text Timer;
    TimeSpan startTime; //= DateTime.Now.TimeOfDay;
    TimeSpan Time; //= DateTime.Now.TimeOfDay;
    TimeSpan endTime; //= DateTime.Now.TimeOfDay;
    float math1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        win = false;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        TimerSet();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Start"))
        {
            other.gameObject.SetActive(false);
            start = true;
            startTime = DateTime.Now.TimeOfDay;
            TimerSet();
        }
        if(other.gameObject.CompareTag("End"))
        {
            other.gameObject.SetActive(false);
            win = true;
            endTime = DateTime.Now.TimeOfDay;
            TimerSet();
            SceneManager.LoadScene(0);
        }
    }

    void TimerSet ()
    {
        if(win == false)
        {
            /*
            if(start == true)
            {
                startTime = DateTime.Now.TimeOfDay;
            }*/
            Time = DateTime.Now.TimeOfDay;
            if(start == true)
            {
                math1 = (float)Time.TotalSeconds - (float)startTime.TotalSeconds;
            }
            Timer.text = math1.ToString();
        }
        else
        {
            
            math1 = (float)endTime.TotalSeconds - (float)startTime.TotalSeconds;
            Timer.text = math1.ToString();

        }
    }
}

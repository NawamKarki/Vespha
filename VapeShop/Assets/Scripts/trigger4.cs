﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class trigger4 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;

    private int dial;
    private float timer;
    private bool enterCountdown;

    private bool changeScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //display Vaping Craving question after 3 seconds
        if (enterCountdown)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= 3)
            {
                notice.SetActive(true);
                timer = 0;
            }
        }

        //Change scene to VapingActivity
        if (changeScene)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= 3)
            {
                if (value.text == "YES")
                {
                    SceneManager.LoadScene("VapingActivity");
                    changeScene = false;
                }
                timer = 0;
                
            }
        }
    }

    //When user enters the colliding box
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            enterCountdown = true;

        }
    }

    private void OnTriggerStay(Collider col)
    {

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("value");
            dial += 1;
            if (dial > 5)
            {
                value.text = "YES";
                changeScene = true;
                dial = 0;
            }
            //value.text = dial.ToString();
        }

        if (Input.GetKeyDown("s"))
        {
            dial -= 1;
            if (dial < -5)
            {
                value.text = "NO";
                changeScene = false; 
                dial = 0;
            }
            //value.text = dial.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Debug.Log("Gone");
            //Destroy(question);
            notice.SetActive(false);
            enterCountdown = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System;
//using System.Console;



public class arduino : MonoBehaviour
{
    //[Serializable] GameObject smoke;
    //public GameObject smok;

    [SerializeField] ParticleSystem smo;



    //functionality to receive data from the serial port
    SerialPort sp = new SerialPort("COM5", 12600);
    string distance;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            sp.Open(); //open the serial port
            sp.ReadTimeout = 101;
            //sp.DataReceived += DataReceivedHandler;
        }

        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);
        }

    }

    // Update is called once per frame
    void Update()
    {

        int ard1 = int.Parse(sp.ReadLine());
        //Debug.Log(ard1/100);

        if (ard1 / 100 > 400)
        {
            //smo.startSize = 0.1f; //controls the size of the smoke
            Debug.Log(ard1 / 100);
            smo.Play();
        }
    }

    //private void DataReceivedHandler(
    //                              object sender,
    //                              SerialDataReceivedEventArgs e)
    //{
    //    SerialPort sp1 = (SerialPort)sender;
    //    string distance = sp1.ReadLine();
    //    Debug.Log(distance);
    //}
}

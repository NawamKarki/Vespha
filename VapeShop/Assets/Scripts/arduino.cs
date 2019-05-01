using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System;
//using System.Console;



public class arduino : MonoBehaviour
{

    [SerializeField] ParticleSystem smo;

    string path;

    //Saving vape inhaling data, giving inital value of 400
    int vapingData =0;

    float timer;


    //Receive data from the serial port
    SerialPort sp = new SerialPort("COM5", 12600);
    string distance;

    // Start is called before the first frame update
    void Start()
    {
        createTxt();

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
        //Get value from the Flow sensor
        int ard1 = int.Parse(sp.ReadLine());
        int ard = ard1 / 100;
        //Debug.Log(ard1);

        //vapingData = 400;
        //flow sensors default value is around 400
        //arduino sends 2 intial values that are greater than 12000 when entering the scene
        if (ard > 400 && ard < 1000 )
        {
            //smo.startSize = 0.1f; //controls the size of the smoke
    
            if (ard >= vapingData)
            {
                vapingData = ard;            
            }
            else if (ard < vapingData)
            {
                Debug.Log(vapingData);
                addTxt(vapingData);
            }
        
            smo.Play();
        }
        //return vapingData;
    }

    //Creates a file in the Assests directory
    private void createTxt()
    {
        path = Application.dataPath;

        if (!File.Exists(path))
        {
            File.WriteAllText(path + "/" + DateTime.Today.ToString("yyyyMMddhh") + ".csv", "");
        }  
    }

    //Add the new inhaling data in the file
    private void addTxt(int data)
    {
        path = Application.dataPath;
        File.AppendAllText(path + "/" + DateTime.Today.ToString("yyyyMMddhh") + ".csv", "\n" + data);
        Debug.Log("Saved");
        vapingData = 0;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class trigger7 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;

    private int dial;
    private float timer;
    private bool enterCountdown;

   // private bool changeScene;

    private string path;
    private long count7;

    //Name of the folder to store files
    string folderName = DateTime.Now.ToString("yyyy-MM-dd");

    // Start is called before the first frame update
    void Start()
    {
        //Sets the path for the game up to the Assets folder
        path = Application.dataPath;
   
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
    }

 
    //When user enters the colliding box
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            //get the file count value
            count7 = mainScript.count;
            enterCountdown = true;

        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown("w"))
        {
            //Debug.Log("value");
            dial += 1;
            value.text = dial.ToString();
        }

        if (Input.GetKeyDown("s"))
        {
            dial -= 1;
            value.text = dial.ToString();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            //Debug.Log("Gone");
            addValue(value.text);
            //Destroy(question);
            notice.SetActive(false);
            enterCountdown = false;
        }
    }

    private void addValue(string dial)
    {
        Debug.Log("trigger7");
        //Debug.Log("7" + count);
        
        File.AppendAllText(path + "/" + folderName + "/participant " + count7 + ".csv", "\n" + dial);
    }
}

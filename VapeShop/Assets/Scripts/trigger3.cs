using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class trigger3 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;
 
    private int dial;
    private float timer;
    private bool enterCountdown;

    private string path;
    private long count3;

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

    //number of files in the directory
    private long DirCount(DirectoryInfo d)
    {
        long i = 0;
        // Add file sizes
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            if (fi.Extension.Contains("csv"))
                i++;
        }
        return i;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            count3 = mainScript.count;
            enterCountdown = true;
        }
    }

    private void OnTriggerStay(Collider col)
    {

        if (Input.GetKeyDown("w"))
        {
            Debug.Log("value");
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
            Debug.Log("Gone");

            addValue(value.text);
            //Destroy(question);
            notice.SetActive(false);
            enterCountdown = false;
        }
    }

    private void addValue(string dial)
    {
        File.AppendAllText(path + "/" + folderName + "/participant " + count3 + ".csv", "\n" + dial);
    }
}

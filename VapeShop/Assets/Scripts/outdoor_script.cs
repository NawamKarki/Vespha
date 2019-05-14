using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class outdoor_script : MonoBehaviour
{
    [SerializeField] GameObject cravingQuestion;
    [SerializeField] Text value;

    private int dial;
    private float timer;
    private bool enterCountdown;

    private string path;
    private static long count2;

    //Name of the folder to store files
    string folderName = DateTime.Now.ToString("yyyy-MM-dd");

    // Start is called before the first frame update
    void Start()
    {
        //Sets the path for the game up to the Assets folder
        path = Application.dataPath + "/Data/CravingData";

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
                cravingQuestion.SetActive(true);
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
            count2 = mainScript.count;
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
            cravingQuestion.SetActive(false);
            enterCountdown = false;
        }
    }

    private void addValue(string dial)
    {
        
        File.AppendAllText(path + "/" + folderName + "/participant " + count2 + ".csv", "\n" + dial);
    }
}

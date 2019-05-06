using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class triggerPoint5 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;

    private int dial;
    private float timer;
    private bool enterCountdown;

    private string path;
    private long file;

    //Name of the folder to store files
    string folderName_bar = "Bar_Scenario " + DateTime.Now.ToString("yyyy-MM-dd");


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            file = mainScript_bar.count;
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
            //Debug.Log("Gone");
            //Destroy(question);
            addValue(value.text);
            notice.SetActive(false);
            enterCountdown = false;
        }
    }

    private void addValue(string dial)
    {

        File.AppendAllText(path + "/" + folderName_bar + "/participant " + file + ".csv", "\n" + dial);
    }
}

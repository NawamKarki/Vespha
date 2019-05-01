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

    // Start is called before the first frame update
    void Start()
    {
        
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
        string path = Application.dataPath + "/dialdata";
        //File.AppendAllText(path + "/participant" + participantNo + ".csv", "\n" + dial);
    }
}

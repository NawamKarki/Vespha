using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class trigger2 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;

    private int dial;
    private float timer;
    private bool enterCountdown;

    private string participantNo;
 
    // Start is called before the first frame update
    void Start()
    {
        //Finding the Participant Number
        //participantNo = GameObject.Find("Participant_No_Trigger_doorFront").GetComponent<greetCustomer>().ParticipantNumber;
        //Debug.Log(participantNo);

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

    //adds the dial value to the file
    private void addValue(string dial)
    {
        string path = Application.dataPath + "/dialdata";
       // File.AppendAllText(path + "/participant" + participantNo +".csv", "\n" + dial);

    }
}

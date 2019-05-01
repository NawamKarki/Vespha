using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class trigger3 : MonoBehaviour
{
    [SerializeField] GameObject notice;
    [SerializeField] Text value;
    [SerializeField] GameObject indoor_receptionist;

    private int dial;
    private float timer;
    private bool enterCountdown;
    private Animator indoor_receptionist_talk;

    private string participantNo;

    // Start is called before the first frame update
    void Start()
    {
        //Finding the Participant Number
        //participantNo = GameObject.Find("Participant_No_Trigger_doorFront").GetComponent<greetCustomer>().ParticipantNumber;
        //Debug.Log(participantNo);
        indoor_receptionist_talk = indoor_receptionist.GetComponent<Animator>();
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
            indoor_receptionist_talk.Play("talk_indoor");

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
        string path = Application.dataPath + "/dialdata";
        File.AppendAllText(path + "/participant" + participantNo + ".csv", "\n" + dial);
    }
}

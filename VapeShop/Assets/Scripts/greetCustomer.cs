using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

using UnityEngine.SceneManagement;

public class greetCustomer : MonoBehaviour
{

    [SerializeField] GameObject receptionist; //doorfront avatar

    private Animator receptionist_talk; //Animation of the doorfront avatar


    // Start is called before the first frame update
    void Start()
    {
        receptionist_talk = receptionist.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //displaying the craving level meter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {        
            receptionist.GetComponent<AudioSource>().Play();
            receptionist_talk.Play("talk");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class greetIndoor : MonoBehaviour
{
    [SerializeField] GameObject receptionist;

    private Animator receptionist_talk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Debug.Log("animate inanimate");
            //animate and make the avatar talk
            //receptionist.GetComponent<AudioSource>().Play();
            receptionist_talk = receptionist.GetComponent<Animator>();
            receptionist_talk.Play("mixamo_com");

        }
    }
}

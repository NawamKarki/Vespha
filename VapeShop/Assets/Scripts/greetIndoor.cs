using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greetIndoor : MonoBehaviour
{
    [SerializeField] GameObject receptionist;

    private Animator receptionist_talk;

    // Start is called before the first frame update
    void Start()
    {
        receptionist_talk = receptionist.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            //enterCountdown = true;
            //animate and make the avatar talk
            receptionist.GetComponent<AudioSource>().Play();
            receptionist_talk.Play("talk");
        }
    }
}

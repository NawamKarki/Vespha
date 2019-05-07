using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveOnTrigger2 : MonoBehaviour {

    public GameObject car1, car2, car3, car4, car5;
    //public GameObject busRed;
    //public GameObject carWhite;

    private Animator drive1, drive2, drive3, drive4, drive5;
    //private Animator bus;
    //private Animator car;
    //public Animator runningFem;
    //public TextMesh score;
    //private Animation runningFem;

    // Use this for initialization
    void Start () {
        drive1 = car1.GetComponent<Animator>();
        drive2 = car2.GetComponent<Animator>();
        drive3 = car3.GetComponent<Animator>();
        drive4 = car4.GetComponent<Animator>();
        drive5 = car5.GetComponent<Animator>();

        //runningFem = runningFemale.GetComponent<Animator>();
        //bus = busRed.GetComponent<Animator>();
        //car = carWhite.GetComponent<Animator>();
    }

    void Update()
    {
    }

       // Update is called once per frame

    void OnTriggerEnter(Collider col)
    {
        //GameObject runningFemale;
        if (col.gameObject.tag == "MainCamera")
        {
            drive1.Play("drive");
            drive2.Play("drive");
            drive3.Play("drive");
            drive4.Play("drive");
            drive5.Play("drive");

            //Debug.Log("Camera entered Trigger");
            //runningFem.Play("JogForward");
            //bus.Play("bus");
            //car.Play("car1");
            //runningFemale.GetComponent<Animation>().Play();
            //Debug.Log(runningFemale.GetComponent<Animator>());
            //runningfemale.setbool("run", true);
            //score.text = "collided with: " + col.getcomponent<collider>().name;
            //Debug.Log("Collision Altertttttt");
            //runningFemale.animation.Play("JogForward_NtrlFaceFwd 0")
            Destroy(gameObject);
            //Destroy(GameObject 'car1', 'car2');
            drive1.StopPlayback();
            drive2.StopPlayback();
            drive3.StopPlayback();
          

        }
    }


}

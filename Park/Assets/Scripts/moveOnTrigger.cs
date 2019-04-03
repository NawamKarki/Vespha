using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveOnTrigger : MonoBehaviour {
    
    //public GameObject runningFemale;
    public GameObject busRed;
    public GameObject carWhite;
    public GameObject VapingF;

    //private Animator runningFem;
    private Animator bus;
    private Animator car;
    private Animator vaping;
    //public Animator runningFem;
    //public TextMesh score;
    //private Animation runningFem;

    // Use this for initialization
    void Start () {
        //runningFem = runningFemale.GetComponent<Animator>();
        bus = busRed.GetComponent<Animator>();
        car = carWhite.GetComponent<Animator>();
        vaping = VapingF.GetComponent<Animator>();
    }

    void Update()
    {
    }

       // Update is called once per frame

    void OnTriggerEnter(Collider col)
    {
        //GameObject runningFemale;
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Camera entered Trigger");
            //runningFem.Play("JogForward");
            bus.Play("bus");
            car.Play("car1");
            vaping.Play("WalkFWD");
            //runningFemale.GetComponent<Animation>().Play();
            //Debug.Log(runningFemale.GetComponent<Animator>());
            //runningfemale.setbool("run", true);
            //score.text = "collided with: " + col.getcomponent<collider>().name;
            //Debug.Log("Collision Altertttttt");
            //runningFemale.animation.Play("JogForward_NtrlFaceFwd 0")
            Destroy(gameObject);
        }
    }


}

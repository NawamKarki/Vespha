using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveOnTrigger3 : MonoBehaviour {
    
    public GameObject runningFemale;

    private Animator runningFem;
   

    // Use this for initialization
    void Start () {
        runningFem = runningFemale.GetComponent<Animator>();
        
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
            //Debug.Log("Camera entered Trigger");
            runningFem.Play("JogForward");
           
         
            Destroy(gameObject);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remoteControl : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("rwwwwwwww");

        OVRInput.Update();

        //transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.Remote);
        //transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.Remote);





        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("remote click");
        }

        //if (OVRInput.GetDown(OVRInput.Button.DpadRight, OVRInput.Controller.Remote))
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //    Debug.Log("Oculus Remote move right");
        //}
        //if (OVRInput.GetDown(OVRInput.Button.DpadLeft, OVRInput.Controller.Remote))
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //    Debug.Log("Oculus Remote move left");
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeTrigger_busStandMan1 : MonoBehaviour {

    //instance of the smoke particle system
    [SerializeField] ParticleSystem smoke;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("In");
            smoke.Play();
        }
    }
}

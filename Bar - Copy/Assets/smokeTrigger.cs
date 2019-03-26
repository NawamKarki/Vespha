using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeTrigger : MonoBehaviour
{

    //instance of the smoke particle system
    public ParticleSystem smoke;

    // Use this for initialization
    void Start()
    {
        Debug.Log("haha");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("haha");
            smoke.Play();
        }
    }
}
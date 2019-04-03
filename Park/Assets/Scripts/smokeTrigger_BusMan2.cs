using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeTrigger_BusMan2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem smoke;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Out");
            smoke.Play();
        }
    }
}

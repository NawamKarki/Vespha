using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmScript : MonoBehaviour {

    public AudioSource Alarm;

	// Use this for initialization
	void Start () {
        Alarm = GetComponent<AudioSource>();
        Alarm.Play();
        Debug.Log("Play");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGazeEnter()
    {
        Alarm.Stop();
        Debug.Log("Stop");
        Destroy(gameObject);
    }
}

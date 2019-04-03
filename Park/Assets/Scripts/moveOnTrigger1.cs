using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moveOnTrigger1 : MonoBehaviour {

    public GameObject[] man = new GameObject[6];
    private Animator[] walk = new Animator[6];
   
    // Use this for initialization
    void Start () {

        for (int a = 0; a <= 5; a++)
        {
            walk[a] = man[a].GetComponent<Animator>();
        }
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
            for (int a = 0; a <= 5; a++)
            {
                walk[a].Play("WalkFWD");
            }
         Destroy(gameObject);
        }
    }


}

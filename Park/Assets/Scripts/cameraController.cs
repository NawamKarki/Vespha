using UnityEngine;

public class cameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public bool cameraPosition = false;
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = transform.position;

        print(pos);

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime / 10;
            if (pos.z == -200.00)
            {
                cameraPosition = true;
            }
        }
        transform.position = pos;

        if (Input.GetKey("a"))
        {
            pos.x += - panSpeed * Time.deltaTime / 10;
        }
        transform.position = pos;

        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime / 10;
        }
        transform.position = pos;

        if (Input.GetKey("s"))
        {
            pos.z += - panSpeed * Time.deltaTime / 10;
        }
        transform.position = pos;

    }
}

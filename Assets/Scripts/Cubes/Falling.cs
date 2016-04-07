using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 returnPos;
    public GameObject thisObject;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        returnPos = transform.position;
        thisObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -20f)
        {
            Destroy(gameObject);
            Instantiate(thisObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "FPSController") {
            rb.useGravity = true;
        }
    }
}

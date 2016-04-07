using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void PickedUp() {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Platform")
        {
            transform.parent = hit.transform;
        }
        else {
            transform.parent = null;
        }
    }
}

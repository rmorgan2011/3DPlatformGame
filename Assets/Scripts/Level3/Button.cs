using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject bridge;
    public Quaternion rotation = Quaternion.Euler(new Vector3(0, 30, 0));
    public Vector3 setRotation;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void RotateBridge() {
        bridge.transform.Rotate(0,90f,0); ;
    }

    void ActivateButton() {
        RotateBridge();
    }

    

}

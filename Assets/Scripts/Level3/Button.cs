using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject bridge;
    public GameObject platform;
    public Quaternion rotation = Quaternion.Euler(new Vector3(0, 30, 0));
    public Vector3 setRotation;

    // Use this for initialization
    void Start () {
        if(platform != null)
        {
            platform.SetActive(false);
        }
  	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void RotateBridge() {
        bridge.transform.Rotate(0,90f,0); ;
    }
    void ActivatePlat()
    {
        platform.SetActive(true);
    }
    void ActivateButton() {
        if(bridge != null)
        {
            RotateBridge();
        }
        if (platform != null)
        {
            ActivatePlat();
        }
    }

    

}

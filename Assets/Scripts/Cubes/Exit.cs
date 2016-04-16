using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    public string loadlevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayerExits() {
        Application.LoadLevel("Start");
    }
}

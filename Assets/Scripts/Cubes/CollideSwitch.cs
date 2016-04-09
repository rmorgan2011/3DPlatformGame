using UnityEngine;
using System.Collections;

public class CollideSwitch : MonoBehaviour {

    public GameObject activate;
    public bool switched;
    public CollideSwitch[] switches;
    public bool allActive;

	// Use this for initialization
	void Start () {
        switched = false;
        allActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        int count = 0;
        for (int i = 0; i < switches.Length; i++) {
            if (switches[i].switched == true) {
                count++;
            }
            else
            {
                count = 0;
            }
        }
        if (count >= switches.Length) {
            allActive = true;
            activate.SetActive(true);
        }
	}

    void Switched() {
        switched = true;
    }
}

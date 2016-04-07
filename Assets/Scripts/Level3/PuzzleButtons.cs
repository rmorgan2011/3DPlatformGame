using UnityEngine;
using System.Collections;

public class PuzzleButtons : MonoBehaviour {

    public GameObject platform;

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activated() {
        this.gameObject.SetActive(true);
    }

    void Pressed() {
        platform.SendMessage("Pressed");
    }
}

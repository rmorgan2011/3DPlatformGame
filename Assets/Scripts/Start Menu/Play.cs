using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Text pToPlay;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.P)) {
            Application.LoadLevel("Level");
        }      
    }
}

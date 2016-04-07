using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public Material isCheckpointM;
    public Material isNotCheckpointM;
    public bool isCheckpoint;
    public GameObject playerFP;
    public PlayerPickup pickup;
    public bool resetCubes;

	// Use this for initialization
	void Start () {
        isCheckpoint = false;
        playerFP = GameObject.Find("FirstPersonCharacter");
        pickup = playerFP.GetComponent<PlayerPickup>();

	}
	
	// Update is called once per frame
	void Update () {
        if (isCheckpoint == false){
            this.gameObject.GetComponent<Renderer>().material = isNotCheckpointM;
        }
        else {
            this.gameObject.GetComponent<Renderer>().material = isCheckpointM;
        }
	}

    void HasBeenReached() {
        isCheckpoint = true;
        if (resetCubes == true) {
            pickup.playerCubes = 0;
            pickup.cubeText.text = "Cubes: 0";
        }
    }
}

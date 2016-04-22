using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {

    public int playerCubes;
    public GameObject cube;
    public GameObject cube2;
    public float reach;
    public Text cubeText;
    public GameObject levelmanager;

	// Use this for initialization
	void Start () {
        playerCubes = 0;
        reach = 6f;
	}
	
	// Update is called once per frame
	void Update () {
        // try to pickup a cube
        if (Input.GetKey(KeyCode.Mouse0)) {
            RaycastHit pickableHit; //detected
            Ray pickableRay = new Ray(transform.position, transform.forward); // checkEnemy
            if (Physics.Raycast(pickableRay, out pickableHit, reach))
            {
                if (pickableHit.transform.GetComponent<Pickable>())
                {
                    pickableHit.transform.SendMessage("PickedUp");
                }
                if (pickableHit.collider.tag == "Pickable")
                {
                    playerCubes++;
                    cubeText.text = "Cubes: " + playerCubes;
                }
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if ((playerCubes > 0)) {
                RaycastHit pickableHit; //detected
                Ray pickableRay = new Ray(transform.position, transform.forward); // checkEnemy
                if (Physics.Raycast(pickableRay, out pickableHit, reach))
                {
                    if (pickableHit.transform.gameObject.tag == "Switch")
                    {
                        var go = Instantiate(cube2, pickableHit.point, Quaternion.identity) as GameObject;
                        pickableHit.transform.gameObject.SendMessage("Switched");
                        //go.transform.parent = levelmanager.transform;
                    }
                    else {
                        var go = Instantiate(cube, pickableHit.point, Quaternion.identity) as GameObject;
                        //go.transform.parent = levelmanager.transform;
                    }
                    playerCubes--; 
                    // if the player has their ping pong ability selected
                    //go.AddComponent<Move_PingPong>();
                }
                else {
                    playerCubes--;
                    var go = Instantiate(cube, transform.position+(transform.forward*6), Quaternion.identity) as GameObject;
                    //go.transform.parent = levelmanager.transform;
                }
                cubeText.text = "Cubes: " + playerCubes;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
                RaycastHit pickableHit; //detected
                Ray pickableRay = new Ray(transform.position, transform.forward); // checkEnemy
                if (Physics.Raycast(pickableRay, out pickableHit, reach))
                {
                if (pickableHit.transform.GetComponent<Button>())
                {
                    pickableHit.transform.SendMessage("ActivateButton");
                }
                if (pickableHit.transform.GetComponent<PuzzleButtons>())
                {
                    pickableHit.transform.SendMessage("Pressed");
                }
                if(pickableHit.transform.GetComponent<PuzzleCube>())
                    pickableHit.transform.SendMessage("ClickedPuzzleCube");
                }
                else {
                    //
                }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PuzzleBoard : MonoBehaviour {

    public List<PuzzleCube> cubes = new List<PuzzleCube>();
    public PuzzleBoard matchingPuzzle;
    public int amountMatching;
    public List<Transform> children = new List<Transform>();
    public bool solved = false;
    public GameObject activatedObject;
    public GameObject activatedObject2;
    public GameObject activatedObject3;

    // Use this for initialization
    void Start () {
        int i;
        for (i = 0; i < this.gameObject.transform.childCount; i++) {
            children.Add(this.gameObject.transform.GetChild(i));
            //Debug.Log("adding child");
        }
        for (i = 0; i < children.Count; i++) {
            cubes.Add(children[i].GetComponent<PuzzleCube>());
        } 
	}
	
	// Update is called once per frame
	void Update () {
        checkSolved();
	}

    void checkSolved() {
        if (solved == false) {
            amountMatching = 0;
            for (int i = 0; i < cubes.Count; i++)
            {
                if (cubes[i].activity.Equals(matchingPuzzle.cubes[i].activity))
                {
                    amountMatching++;
                }
                else {
                    amountMatching = 0;
                }
            }
            if (amountMatching >= cubes.Count)
            {
                solved = true;
            }
            if (matchingPuzzle.solved == true) {
                solved = true;
                // send message to the game object
                activatedObject.SetActive(true);
                if (activatedObject2)
                {
                    activatedObject2.SetActive(true);
                }
                if (activatedObject3)
                {
                    activatedObject3.SetActive(true);
                }
            }
        }
    }
}

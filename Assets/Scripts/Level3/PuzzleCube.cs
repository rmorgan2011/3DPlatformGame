using UnityEngine;
using System.Collections;

public class PuzzleCube : MonoBehaviour {

    public int activity;
    public Material active;
    public Material notActive;
    public Material solved;
    //public Material finished;
    public Renderer rend;
    public PuzzleBoard parent;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        parent = GetComponentInParent<PuzzleBoard>();
    }
	
	// Update is called once per frame
	void Update () {
        if (activity == 1)
        {
            // update skin
            rend.material = active;
        }
        else if (activity == 0)
        {
            // update skin
            rend.material = notActive;
        }

        if (parent.solved == true && activity != 2)
        {
            activity = 2;
            rend.material = solved;
        }
    }

    void ClickedPuzzleCube() {
        if (activity == 1)
        {
            activity = 0;
        }
        else if(activity == 0){
            activity = 1;
        }
    }
}

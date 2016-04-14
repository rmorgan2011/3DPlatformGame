using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public Material isCheckpointM;
    public Material isNotCheckpointM;
    public bool isCheckpoint;
    public GameObject playerFP;
    public PlayerPickup pickup;
    public bool resetCubes;
    public GameObject ringsUp;
    public GameObject ringsDown;
    // Use this for initialization
    void Start()
    {
        isCheckpoint = false;
        playerFP = GameObject.Find("FirstPersonCharacter");
        pickup = playerFP.GetComponent<PlayerPickup>();
        ringsUp = GameObject.Find("RingsUp");
        ringsDown = GameObject.Find("RingsDown");
        ringsUp.GetComponent<ParticleSystem>().playbackSpeed = 0;
        ringsDown.GetComponent<ParticleSystem>().playbackSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckpoint == false)
        {
            this.gameObject.GetComponent<Renderer>().material = isNotCheckpointM;
        }
        else {
            this.gameObject.GetComponent<Renderer>().material = isCheckpointM;
        }
    }

    void HasBeenReached()
    {
        this.gameObject.GetComponent<Rotator>().enabled = false;
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        expandXYZ();
        if (resetCubes == true)
        {
            pickup.playerCubes = 0;
            pickup.cubeText.text = "Cubes: 0";
        }
    }

    void expandXYZ()
    {
        if (this.gameObject.transform.localScale.x < 2.4f || this.gameObject.transform.localScale.z < 2.4f)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + .25f,
                                                           this.gameObject.transform.localScale.y,
                                                           this.gameObject.transform.localScale.z + .25f);
            Invoke("expandXYZ", .15f);
        }
        else if (this.gameObject.transform.localScale.y < 2.4f)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x,
                                                           this.gameObject.transform.localScale.y + .25f,
                                                           this.gameObject.transform.localScale.z);
            Invoke("expandXYZ", .2f);
        }
        else
        {
            isCheckpoint = true;
            ringsDown.transform.position = this.gameObject.transform.position;
            ringsUp.transform.position = ringsDown.transform.position;
            ringsUp.GetComponent<ParticleSystem>().playbackSpeed = 1;
            ringsDown.GetComponent<ParticleSystem>().playbackSpeed = 1;

        }

    }
}

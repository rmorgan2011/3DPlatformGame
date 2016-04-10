using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public PlayerPickup playerPickup;
    public Transform player;
    public Vector3 checkpoint;
    public GameObject levelManager;
    public Rigidbody rb;
    public bool collide;
    public CharacterController cc;

    public Animator goalAnimator;
    public GameObject goal;

    private GameObject checkpointGO;

    // Use this for initialization
    void Start()
    {
        checkpointGO = null;
        player = this.gameObject.transform.GetChild(0);
        playerPickup = player.GetComponent<PlayerPickup>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find current goal
        goal = GameObject.Find("Goal");
        goalAnimator = goal.GetComponent<Animator>();

        if (Input.GetAxis("Mouse ScrollWheel") > 0.2){
            //swapAbility(up);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < -0.2)
        {
            //swapAbility(down);
        }
        if (transform.position.y < checkpoint.y - 100f) {
            transform.position = checkpoint;
        }
    }

    void UpdateCheckpoint()
    {
        if (checkpointGO != null)
        {
            checkpoint = checkpointGO.transform.position;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Platform")
        {
            transform.parent = hit.transform;
        }
        else {
            transform.parent = null;
        }

        if (hit.gameObject.tag == "Boost")
        {
            collide = true;
            rb.AddRelativeForce(hit.transform.forward * 100f, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Goal")
        {
            // player wins level
            //currentLevel++;
            levelManager.SendMessage("LoadLevel");
            CapsuleCollider cap = hit.gameObject.GetComponent<CapsuleCollider>();
            cap.isTrigger = false;
            goalAnimator.Play("GoalReached");
            Destroy(hit.gameObject, 1.0f);
        }
        if (hit.gameObject.tag == "Checkpoint") {
            checkpointGO = hit.gameObject;
            checkpoint = hit.gameObject.transform.position;
            hit.SendMessage("HasBeenReached");
        }
        if (hit.gameObject.tag == "Exit")
        {
            hit.SendMessage("PlayerExits");
        }
        if (hit.gameObject.tag == "Death") {
            transform.position = checkpoint;
        }
    }
}
using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour
{


    public Transform player;
    private Transform pivot;

    private bool isFlipping;
    private float timeF;
    private float rotTimer;
    public float cooldownShouldBe2;
    public float speed;

    public GameObject emptyPreFab;
    private GameObject pivotGO;
    // Use this for initialization
    void Start()
    {
        isFlipping = false;
        timeF = Mathf.NegativeInfinity;
        rotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //press f to start cooldown timer
        //and prep for flip
        if (Input.GetKeyDown(KeyCode.F) && Time.timeSinceLevelLoad > timeF + cooldownShouldBe2)
        {
            rotTimer = 0;
            timeF = Time.timeSinceLevelLoad;
            isFlipping = true;
            
            //place prefab get its transform
            pivotGO = Instantiate(emptyPreFab, player.position, Quaternion.Euler(0, player.localRotation.eulerAngles.y, 0)) as GameObject;
            pivot = pivotGO.GetComponent<Transform>();

            //pivot.rotation = Quaternion.Euler(0, player.localRotation.eulerAngles.y, 0); //this might not be necessary

            transform.parent = pivot;
            
        }

        if (isFlipping)
        {

            //this works pretty well
            if ((pivot.localRotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0, pivot.rotation.eulerAngles.y, 180), Time.deltaTime * speed)) == pivot.rotation)
            {
                player.gameObject.SendMessage("UpdateCheckpoint");
            }//when you're done flipping, find the new placement of the checkpoint


            if (timeF + cooldownShouldBe2 < Time.timeSinceLevelLoad)
            {
                isFlipping = false;
            } //after 2 seconds flipping process is done.
        }
        else
        {
            transform.parent = null;
            Destroy(pivotGO);
        }//make sure all intialized variables are gone
    }



}


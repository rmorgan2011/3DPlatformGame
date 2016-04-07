using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour
{

    //this is how it works
    //press f
    //freeze time?
    //finds player as pivot point (grab global position, local rotation)
    //rotate everything around that with lerp
    //?unfreeze time

    //this is level
    public Transform player;
    public Transform pivot;

    private bool isFlipping;
    private float timeF;
    private float rotTimer;
    public float cooldownShouldBe2;
    public float speed;
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
        if (Input.GetKeyDown(KeyCode.F) && Time.timeSinceLevelLoad > timeF + cooldownShouldBe2)
        {
            rotTimer = 0;
            timeF = Time.timeSinceLevelLoad;
            isFlipping = true;
            pivot.position = player.position;
            pivot.rotation = player.rotation;

            transform.parent = pivot;



        }

        if (isFlipping)
        {
            //this works pretty well

            pivot.rotation = Quaternion.Lerp(pivot.localRotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * speed);//


            if (timeF + cooldownShouldBe2 < Time.timeSinceLevelLoad)
            {
                isFlipping = false;
            }
        }
        else
        {
            transform.parent = null;
        }
    }



}

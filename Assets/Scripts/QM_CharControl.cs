using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// C# translation from http://answers.unity3d.com/questions/155907/basic-movement-walking-on-walls.html
/// Author: UA @aldonaletto 
/// </summary>

// Prequisites: create an empty GameObject, attach to it a Rigidbody w/ UseGravity unchecked
// To empty GO also add BoxCollider and this script. Makes this the parent of the Player
// Size BoxCollider to fit around Player model.

public class QM_CharControl : MonoBehaviour
{

    private float moveSpeed = 10; // move speed
    private float turnSpeed = 90; // turning speed (degrees/second)
    private float lerpSpeed = 10; // smoothing speed
    private float gravity = 10; // gravity acceleration
    private bool isGrounded;
    private float deltaGround = 0.2f; // character is grounded up to this distance
    private float jumpSpeed = 10; // vertical jump initial speed
    private float jumpRange = 10; // range to detect target wall
    private Vector3 surfaceNormal; // current surface normal
    private Vector3 myNormal; // character normal
    private float distGround; // distance from character position to ground
    private bool jumping = false; // flag &quot;I'm jumping to wall&quot;
    private float vertSpeed = 0; // vertical jump current speed

    private Transform myTransform;
    public BoxCollider boxCollider; // drag BoxCollider ref in editor

    private bool gravityMode = true;

    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float speed = 5;

    public GameObject player;
    [SerializeField]
    Camera Camera;

    [Range(10f, 50f)]
    public float Speed = 30;

    private void Start()
    {
        myNormal = transform.up; // normal starts as character up direction
        myTransform = transform;
        GetComponent<Rigidbody>().freezeRotation = true; // disable physics rotation
                                         // distance from transform.position to ground
        distGround = boxCollider.extents.y - boxCollider.center.y;
        originalRotation = Camera.transform.localRotation;
    }

    private void FixedUpdate()
    {
        // apply constant weight force according to character normal:
        GetComponent<Rigidbody>().AddForce(-gravity * GetComponent<Rigidbody>().mass * myNormal);
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
     
        // jump code - jump to wall or simple jump
        if (jumping) return; // abort Update while jumping to a wall

        Ray ray;
        RaycastHit hit;

        if (Input.GetButtonDown("Jump"))
        { // jump pressed:
        
                ray = new Ray(myTransform.position, myTransform.forward);
                if (Physics.Raycast(ray, out hit, jumpRange))
                { // wall ahead?
                    JumpToWall(hit.point, hit.normal); // yes: jump to the wall
                }
                else if (isGrounded)
                { // no: if grounded, jump up
                    GetComponent<Rigidbody>().velocity += jumpSpeed * myNormal;
                }
       
        }
        // movement code - turn left/right with Horizontal axis:
        // player.GetComponentInChildren<Transform>().Rotate(-Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);
        transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed * Time.deltaTime, transform.rotation * Vector3.up) * transform.rotation;
        Camera.transform.rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * Speed * Time.deltaTime, Camera.transform.rotation * Vector3.right) * Camera.transform.rotation;
        // myTransform.Rotate (-Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime, 0, 0);
        // rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        //  rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

        //  Quaternion xQuaternion = (Quaternion.AngleAxis(rotationX, myNormal + Vector3.up));
        // Quaternion yQuaternion = (Quaternion.AngleAxis(rotationY, - myNormal + Vector3.left));

        //  transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        //  rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        //rotationY += transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivityY;
        // rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        //transform.localEulerAngles.y += Input.GetAxis("Mouse X") * speed;
        ray = new Ray(myTransform.position, -myNormal); // cast ray downwards
            if (Physics.Raycast(ray, out hit))
            { // use it to update myNormal and isGrounded
                isGrounded = hit.distance <= distGround + deltaGround;
                surfaceNormal = hit.normal;
            }
            else {
                isGrounded = false;
                // assume usual ground normal to avoid "falling forever"
                surfaceNormal = Vector3.up;
            }
            myNormal = Vector3.Lerp(myNormal, surfaceNormal, lerpSpeed * Time.deltaTime);
            // find forward direction with new myNormal:
            Vector3 myForward = Vector3.Cross(myTransform.right, myNormal);
            // align character to the new myNormal while keeping the forward direction:
            Quaternion targetRot = Quaternion.LookRotation(myForward, myNormal);
      
        myTransform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime,0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }

    private void JumpToWall(Vector3 point, Vector3 normal)
    {
        // jump to wall
        jumping = true; // signal it's jumping to wall
        GetComponent<Rigidbody>().isKinematic = true; // disable physics while jumping
        Vector3 orgPos = myTransform.position;
        Quaternion orgRot = myTransform.rotation;
        Vector3 dstPos = point + normal * (distGround + 0.5f); // will jump to 0.5 above wall
        Vector3 myForward = Vector3.Cross(myTransform.right, normal);
        Quaternion dstRot = Quaternion.LookRotation(myForward, normal);

        StartCoroutine(jumpTime(orgPos, orgRot, dstPos, dstRot, normal));
        //jumptime
    }

    private IEnumerator jumpTime(Vector3 orgPos, Quaternion orgRot, Vector3 dstPos, Quaternion dstRot, Vector3 normal)
    {
        for (float t = 0.0f; t < 1.0f;)
        {
            t += Time.deltaTime;
            myTransform.position = Vector3.Lerp(orgPos, dstPos, t);
            myTransform.rotation = Quaternion.Slerp(orgRot, dstRot, t);
            yield return null; // return here next frame
        }
        myNormal = normal; // update myNormal
        GetComponent<Rigidbody>().isKinematic = false; // enable physics
        jumping = false; // jumping to wall finished

    }

}
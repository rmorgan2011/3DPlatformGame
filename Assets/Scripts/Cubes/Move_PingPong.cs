using UnityEngine;
using System.Collections;

public class Move_PingPong : MonoBehaviour {

    public float min = 2f;
    public float max = 3f;
    public float length = 10f;
    public Move_PingPong script;
    
    // Use this for initialization
    void Start()
    {
        script = gameObject.GetComponent<Move_PingPong>();
        min = transform.position.x;
        max = transform.position.x + 3;

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 4, length) + min, transform.position.y, transform.position.z);
    }

    void Pressed() {
        if (script.enabled == false)
        {
            script.enabled = true;
        }
        else {
            script.enabled = false;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public string loadlevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayerExits() {
        GameObject[] UI = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject element in UI){
            Destroy(element);
        }
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}

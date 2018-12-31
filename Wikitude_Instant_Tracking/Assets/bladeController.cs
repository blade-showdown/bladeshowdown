using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class bladeController : MonoBehaviour {

    InstantTrackingController trackerScript;
    private GameObject ButtonsParent;
   // protected Joystick joystick;
    private Rigidbody rb;
    public float speed = 10f,boostMultiplier=2f;

    // Use this for initialization
    void Start () {
        trackerScript = GameObject.Find("Controller").gameObject.GetComponent<InstantTrackingController>();
        ButtonsParent = GameObject.Find("Buttons Parent");

        rb = GetComponent<Rigidbody>();
        

        trackerScript._gridRenderer.enabled = false;
        ButtonsParent.SetActive(false);
	}

    void OnEnable()
    {

        trackerScript._gridRenderer.enabled = false;
        ButtonsParent.SetActive(false);

    }

    void OnDisable()
    {
        ButtonsParent.SetActive(true);
    }

    void Update()
    {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");


        Vector3 movement = new Vector3(x*(-1), 0.0f,y*(-1));
        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        Debug.Log(isBoosting ? boostMultiplier : 1);
        rb.velocity = movement * speed *(isBoosting ? boostMultiplier : 1);

    }
}
 
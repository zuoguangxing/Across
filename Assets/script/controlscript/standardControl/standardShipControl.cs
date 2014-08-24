using UnityEngine;
using UnityEditor;
using System.Collections;

public class standardShipControl : MonoBehaviour {
    GameObject ship;
    Transform frontLeftPropeller;
    Transform frontRightPropeller;
    Transform backLeftPropeller;
    Transform backRightPropeller;
    Transform backPropeller;
    Transform frontPropeller;
    Transform frontWing;
    Transform backWing;
    Transform model;
	// Use this for initialization
    void Start()
    {
        ship = GameObject.Find("ship");
        frontWing = transform.Find("/ship/frontWing");
        backWing = transform.Find("/ship/backWing");
        backLeftPropeller = transform.Find("/ship/backLeftWingPropeller");
        backRightPropeller = transform.Find("/ship/backRightWingPropeller");
        frontLeftPropeller = transform.Find("/ship/frontLeftWingPropeller");
        frontRightPropeller = transform.Find("/ship/frontRightWingPropeller");
        backPropeller = transform.Find("/ship/backPropeller");
        frontPropeller = transform.Find("/ship/frontPropeller");
    }
	
	// Update is called once per frame
	void Update () {
	}
    void FixedUpdate(){
         if(Input.GetKey("w"))
        {
            //UnityEngine.Debug.Log("hhe");
           ship.rigidbody.AddForceAtPosition(ship.transform.forward, backPropeller.position);
        }
    }
}

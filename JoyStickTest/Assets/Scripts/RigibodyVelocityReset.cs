using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyVelocityReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void FixedUpdate()
    {
      // GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
       GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().angularDrag = 0;
        GetComponent<Rigidbody>().drag = 0;
    }

}

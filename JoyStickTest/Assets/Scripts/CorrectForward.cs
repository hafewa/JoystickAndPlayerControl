using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectForward : MonoBehaviour {
    public Transform FirstPerson;
    public Transform _camera; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        FirstPerson.forward = _camera.forward;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampXRotation : MonoBehaviour {
    public float yMinLimit;
    public float yMaxLimit;
    float x;
    // Use this for initialization
    void Start () {
        x = transform.eulerAngles.x;

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("=====transform.eulerAngles.y=====" + transform.eulerAngles.y+ "=====transform.eulerAngles.x===" + transform.eulerAngles.x);
        x = Mathf.Clamp(transform.eulerAngles.x, yMinLimit, yMaxLimit);
        var rotation = Quaternion.Euler(x, transform.eulerAngles.y, 0);
        transform.rotation = rotation;
    }
}

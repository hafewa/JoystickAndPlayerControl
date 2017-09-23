using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionSelf : MonoBehaviour {
    public Vector3 transformUP;
    // Use this for initialization
    void Start () {
		
	}
    float mouseX;
    float mouseY;
    Vector3 axis;
    float engle;
    // Update is called once per frame
    void Update () {
        transformUP = transform.up;
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)||Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
            {
                //根据面朝观察者放面设置旋转轴
                if (transformUP.y > 0) axis = Vector3.down;
                else axis = Vector3.up;
                engle = mouseX;
                transform.GetChild(0).Rotate( axis, engle);
            }
            else
            {
                axis = Vector3.right;
                engle = mouseY;
                transform.Rotate(axis, engle);
            }

           
        }
    }
}

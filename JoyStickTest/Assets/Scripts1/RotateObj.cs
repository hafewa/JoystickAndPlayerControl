using UnityEngine;
using System.Collections;

public class RotateObj : MonoBehaviour
{

    public GameObject cube;
    float horizontalSPeed = 2.0f;
    float verticalSpeed = 2f;
    float x, y;
    float speed = 30f;
    float distance = 5;
    Vector3 center;
    // Use this for initialization
    void Start()
    {
        center = cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //        float h = horizontalSPeed * Input.GetAxis ("Mouse X");
        //        float v = verticalSpeed * Input.GetAxis ("Mouse Y");
        //        transform.Rotate (v,h,0);


        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            y += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            Debug.Log("x:  " + x);
            Quaternion q = Quaternion.Euler(y, x, 0);
            Vector3 direction = q * Vector3.forward;
            this.transform.position = center - direction * distance;
            //this.transform.LookAt(center);
        }

    }
}
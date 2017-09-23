using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundTarget : MonoBehaviour {
    public Transform target;
    public float engle;
    Vector3 axis;
	// Use this for initialization
	void Start () {
        engle = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        RotaionNotLaw();
    }

    private void RotaionNotLaw()
    {
        axis = target.forward * Random.Range(0, 10) + target.up * Random.Range(0, 10);
        transform.RotateAround(target.position, axis, Time.deltaTime * 100);
    }

    /// <summary>
    /// 第一种，有规律旋转
    /// </summary>
    private void RotationLaw()
    {
        if (engle < Mathf.PI)
        {
            axis = target.transform.up;
            transform.RotateAround(target.position, axis, Time.deltaTime * 100);
            engle += Time.deltaTime;
            Debug.Log("1");
        }
        else if (engle < Mathf.PI * 1.5f)
        {
            axis = target.transform.up + target.transform.forward;
            transform.RotateAround(target.position, axis, Time.deltaTime * 100);
            engle += Time.deltaTime;
            Debug.Log("2");
        }
        else if (engle < Mathf.PI * 2)
        {
            axis = target.transform.forward;
            transform.RotateAround(target.position, axis, Time.deltaTime * 100);
            engle += Time.deltaTime;
            Debug.Log("3");
        }
        else engle = 0;
    }
}

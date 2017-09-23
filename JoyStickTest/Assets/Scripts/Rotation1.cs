﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour {

    //旋转速度，需要调试
    public float xSpeed = 250.0f;
    public float ySpeed = 130.0f;
    //限制旋转角度，物体绕x轴旋转限制，不能上下颠倒。
    public float yMinLimit = -30;
    public float yMaxLimit = 30;
    //物体的旋转角度
    public float x = 0.0f;
    public float y = 0.0f;
    void Start()
    {
        //初始化旋转角度，记录开始时物体的旋转角度。
        Vector3 angels = transform.eulerAngles;
        x = angels.y;
        y = angels.x;
        //
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //鼠标沿x轴的移动乘以系数当作物体绕y轴的旋转角度。
            //鼠标沿y轴的移动乘以系数当作物体绕x轴的旋转角度。
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }
    }
    void LateUpdate()
    {
        //限制绕x轴的移动。
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        Quaternion rotation = Quaternion.Euler(y, -x, 0);
        transform.rotation = rotation;
    }
}

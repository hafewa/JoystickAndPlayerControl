using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileTouch : MonoBehaviour {
    //控制的第一人称视角
    public Transform FirstPerson;
    //移动角度
     Vector3 angle;
    //灵敏度
    public float sensitivity=0.02f;
    //遥感器
    
    public float yMinLimit;
    public float yMaxLimit;
    //摄像头的位置
    float  x = 0.0f;
    float y = 0.0f;
    //虚拟遥感是否被点击了
    bool joystickIsActive = false;
    // Use this for initialization
    void Start () {
        angle = new Vector3();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //如果点击的虚拟遥感器，则不触发划屏
        //if (joystickLeft.JoystickValue.magnitude != 0 || joystickRight.JoystickValue.magnitude != 0) joystickIsActive = true;
        //else joystickIsActive = false;

    }

    private void ChangeViewAngle()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //根据触摸点计算X与Y位置
            x += Input.GetAxis("Mouse X");
            y -= Input.GetAxis("Mouse Y");
            //重置摄像机的位置
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            var rotation = Quaternion.Euler(y, x, 0);
            FirstPerson.rotation = rotation;
        }
    }

    private void LateUpdate()
    {
        if (joystickIsActive) return;
        ChangeViewAngle();
    }
    static float ClampAngle(float angle  , float min  , float max  )
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
    private void OnGUI()
    {
       // GUI.Label(new Rect(100,100,200,200), "==========" + y + "======" + x);
    }
}

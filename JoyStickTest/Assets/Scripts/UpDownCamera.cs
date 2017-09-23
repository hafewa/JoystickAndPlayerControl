using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownCamera : MonoBehaviour {
    //当前位置
    Vector3 currentPostion;
    //当前位置的y值
    float y;
    // Use this for initialization
    public UIjoysticks joystickLeft;
    public UIjoysticks joystickRight;
    void Start () {
        currentPostion = transform.position;
        y = currentPostion.y;
    }
	
	// Update is called once per frame
	void Update () {
        //如果是地面模式，或者遥感有值输入，则不调整高度
        if ((UIFlyManager.Instance != null && UIFlyManager.Instance.state.ToString() == ModeType.ISGround.ToString()) || (joystickLeft.isPressed|| joystickRight.isPressed)) return;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //根据触摸点计算X与Y位置
            y += Input.GetAxis("Mouse Y");
            //重置摄像机的位置
            currentPostion.y = y;
            transform.position = currentPostion;
        }
    }
}

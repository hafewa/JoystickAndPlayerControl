using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    public UIjoysticks joystickRight;
    public float yLimitMin;
    public float yLimitMax;
    public float xSpeed=0.3f;
    public float ySpeed=0.3f;
    Transform _camera;
    Transform m_tranfrom;
    float x;
    float y;
    Vector3 velocity;
    // Use this for initialization
    void Start () {
        _camera = transform.Find("Camera");
        m_tranfrom = GetComponent<Transform>();
        x = m_tranfrom.eulerAngles.x;
        y = _camera.eulerAngles.y;
        velocity = GetComponent<CharacterController>().velocity;
	}
	
	
    private void FixedUpdate()
    {
        if (joystickRight.offset.magnitude == 0) return;
        x += joystickRight.offset.x * Time.deltaTime * xSpeed; 
        var rotationx = Quaternion.Euler(m_tranfrom.eulerAngles.x, x, 0);
        m_tranfrom.rotation = rotationx;
        //设置摄像机
        y -= joystickRight.offset.y * Time.deltaTime* ySpeed;
        y = Tool.ClampAngle(y,yLimitMin,yLimitMax);
        var rotationy = Quaternion.Euler(y, _camera.eulerAngles.y, 0);
        _camera.rotation = rotationy;
    }
}

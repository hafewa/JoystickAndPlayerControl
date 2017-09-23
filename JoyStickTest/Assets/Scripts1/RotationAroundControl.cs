using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 模型预览相机控制（兼容安卓平台，pc平台控制）
/// 吴勇飞
/// </summary>

public class RotationAroundControl : MonoBehaviour
{
    public Transform target;
    public Vector3 transfromForward;
    public float speed = 1;
    public float fieldMin=30;
    public float fieldMax=80;
    // Use this for initialization
    void Start()
    {
        m_camera = GetComponent<Camera>();
        distance = m_camera.fieldOfView;
    }
    float mouseX;
    float mouseY;
    Vector3 axis;
    float engle;
    Vector2 oldPosition1;
    Vector2 oldPosition2;
    double distance;
    Camera m_camera;
    // Update is called once per frame
    void Update()
    {
        //旋转
        transfromForward = transform.forward;
        //如果是安卓平台
        if (Application.platform == RuntimePlatform.Android)
        {
            AndriodControlView();
            //放大，缩小
            ZoomInOut();
        }
        //如果是pc平台
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            PCControlView();
            //放大，缩小
            ZoomInOutPC();
        }
    }
    /// <summary>
    /// 安卓平台操控
    /// </summary>
    private void AndriodControlView()
    {
        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            RotationView();
        }
    }
    /// <summary>
    /// 旋转相机
    /// </summary>
    private void RotationView()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY))
        {
            axis = Vector3.up;
            engle = mouseX * speed;
        }
        else
        {
            axis = -transform.right;
            engle = mouseY * speed;
        }

        transform.RotateAround(target.position, axis, engle);
    }

    /// <summary>
    /// PC平台操控
    /// </summary>
    private void PCControlView()
    {
        if (Input.GetMouseButton(0))
        {
            RotationView();
        }
    }
    /// <summary>
    /// PC上的方法缩小
    /// </summary>
    private void ZoomInOutPC()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (m_camera.fieldOfView <= fieldMax)
                m_camera.fieldOfView += 2;
            if (m_camera.orthographicSize <= fieldMax*0.2)
                m_camera.orthographicSize += 0.5F;
        }
        //Zoom in  
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (m_camera.fieldOfView > fieldMin)
                m_camera.fieldOfView -= 2;
            if (m_camera.orthographicSize >= fieldMin*0.5)
                m_camera.orthographicSize -= 0.5F;
        }
    }
    /// <summary>
    /// 手机上的放大缩小
    /// </summary>
    private void ZoomInOut()
    {
        if (Input.touchCount > 1)
        {
            //前两只手指触摸类型都为移动触摸  
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                //计算出当前两点触摸点的位置  
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;
                //函数返回真为放大，返回假为缩小  
                if (isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    //范围限制
                    distance -= 0.5;
                    if (distance < fieldMin)
                    {
                        distance = fieldMin;
                    }
                }
                else
                {
                    //范围限制
                    distance += 0.5;
                    if (distance > fieldMax)
                    {
                        distance = fieldMax;
                    }
                }
                //备份上一次触摸点的位置，用于对比  
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
            m_camera.fieldOfView = (float)distance;
        }
    }

    //函数返回真为放大，返回假为缩小  
    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        //函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势  
        var leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        var leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            //放大手势  
            return true;
        }
        else
        {
            //缩小手势  
            return false;
        }
    }
}

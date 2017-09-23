using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	Transform m_t;
	Vector3 moveDirection;
    CharacterController controller;
    public UIjoysticks joystickLeft;
    public float Speed = 1f;
    Transform _camera;
    // Use this for initialization
    void Start () {
		m_t = transform;
        controller = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        _camera = m_t.Find("Camera");
    }
	
	// Update is called once per frame
	
    private void FixedUpdate()
    {
        if (joystickLeft.offset.magnitude != 0&&controller.velocity.magnitude<2)
        {
            //moveDirection.x = joystickLeft.offset.x * Time.deltaTime * xSpeed;
            //moveDirection.z = joystickLeft.offset.y * Time.deltaTime * ySpeed;
            moveDirection = (_camera.forward * joystickLeft.offset.y + _camera.right * joystickLeft.offset.x)* Time.deltaTime* Speed;
        }
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
        }
       
        if (!controller.isGrounded&& UIFlyManager.Instance.state.ToString() == ModeType.ISGround.ToString()) moveDirection.y = -10;
        else moveDirection.y = 0;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSetZSpeed : MonoBehaviour {
    
    public float speedCoefficient = 3;
    Move move;
    Transform m_tranform;
    // Use this for initialization
    void Start () {
        move = GetComponent<Move>();
        m_tranform = GetComponent<Transform>();


    }
	
	// Update is called once per frame
	void Update () {
        //拿到虚拟遥感操纵的对象的高度，并赋值给前进速度参数
        move.Speed =Mathf.Max(1, m_tranform.position.y * speedCoefficient) ;
    }

}

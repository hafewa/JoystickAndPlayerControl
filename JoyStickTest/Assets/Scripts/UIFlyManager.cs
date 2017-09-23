using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ModeType
{
    ISGround,
    IsFly
}
public class UIFlyManager : MonoBehaviour {
   public  enum ModeType
    {
        ISGround,
        IsFly
    }
     public  ModeType state=ModeType.ISGround;
    //public Transform FirstPerson;
    public static UIFlyManager Instance;
	// Use this for initialization
	void Start () {
        Instance = this;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ModeChange(Text text)
    {
        if (state== ModeType.ISGround)
        {
            //切换到航拍模式
           // FirstPerson.GetComponent<Rigidbody>().useGravity = false;
            text.text = "航拍模式";
            state = ModeType.IsFly;
        }
        else
        {
            //切换到地面模式
           // FirstPerson.GetComponent<Rigidbody>().useGravity = true;
            text.text = "地面模式";
            state = ModeType.ISGround;
        }
    }
}

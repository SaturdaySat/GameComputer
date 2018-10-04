using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plugin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.GetInstance().AddEventListener(EventName.Event_Computer_Slot_Click, DoSomething);
	}
	
    public void DoSomething(EventParam param)
    {
        print("Do Some thing");
    }
}

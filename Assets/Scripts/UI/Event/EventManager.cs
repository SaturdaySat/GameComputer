using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum EventName
{
    None,
    Event_Computer_Slot_Click,
    Event_Bag_Item_Click,

    Max,
}

public class EventParam
{

}

public class SlotClickEventParam : EventParam
{
    public ComputerPartBase part;
}

public class BagItemClickEventParam : EventParam
{
    public ComputerPartBase part;
}



[System.Serializable]
public class UIEvent:UnityEvent<EventParam>
{
	
}

public class EventManager : Singleton<EventManager>{
	private Dictionary<EventName, UIEvent> eventDict = new Dictionary<EventName, UIEvent>();


	public void InitManager(){
	
	}

	public void AddEventListener(EventName eventName, UnityAction<EventParam> listener){
		UIEvent thisEvent = null;
		if (GetInstance ().eventDict.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new UIEvent();
			thisEvent.AddListener (listener);
			GetInstance ().eventDict.Add (eventName, thisEvent);
		}
	}

	public void RmvEventListener(EventName eventName, UnityAction<EventParam> listner){
		UIEvent thisEvent = null;
		if (GetInstance ().eventDict.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listner);
		}
	}

	public void SendEvent(EventName eventName, EventParam param){
		UIEvent thisEvent = null;
		if (GetInstance ().eventDict.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke (param);
		}

	}
}

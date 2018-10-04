using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Start () {
		EventManager.GetInstance ().Init ();
		UIManager.GetInstance ().InitManager ();

		UIManager.GetInstance ().PushPanel (UIPanelPath.UI_PANEL_MAINGAME);
	}

	void OnDisable(){
		
	}

	void Update () {
		UIManager.GetInstance ().UpateUI ();
	}


}

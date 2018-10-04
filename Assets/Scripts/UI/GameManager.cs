using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Start () {

        ActorRoot actor = new ActorRoot();
        actor.Init();
        ActorHelper.GetInstance().SetHostActor(actor);

        EventManager.GetInstance ().Init ();
		UIManager.GetInstance ().InitManager ();

		UIManager.GetInstance ().PushPanel (UIPanelPath.UI_PANEL_MAINGAME);

       
    }

	void OnDisable(){
		
	}

	void Update () {
		UIManager.GetInstance ().UpateUI ();
        ActorHelper.GetInstance().GetHostActor().Update();
	}


}

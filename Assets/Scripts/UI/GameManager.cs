using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Start () {
        ActorRoot actor = new ActorRoot();
        actor.Init();
        ActorHelper.GetInstance().SetHostActor(actor);

        //创建电脑
        CPU cpu = new CPU(ComputerPartType.CPU, 1001, 1001, "I9-10000k", "非常牛逼", 100, 50, "LGA2066", 10.0f);
        MotherBoard motherBoard = new MotherBoard(ComputerPartType.MotherBoard, 2001, 2001, "ASAS-X10086", "特别牛逼", 100, 15, cpu);

        ComputerCase comCase = new ComputerCase();
        comCase.Init();
        comCase.MotherBoardSlot.Part = motherBoard;
        actor.maingameLinkerComponent.ComputerCase = comCase;

        MotherBoard motherBoard01 = new MotherBoard(ComputerPartType.MotherBoard, 2002, 2002, "ASAS-X10087", "特别牛逼+1", 100, 15, null);
        MotherBoard motherBoard02 = new MotherBoard(ComputerPartType.MotherBoard, 2003, 2003, "ASAS-X10088", "特别牛逼+2", 100, 15, null);
        MotherBoard motherBoard03 = new MotherBoard(ComputerPartType.MotherBoard, 2004, 2004, "ASAS-X10089", "特别牛逼*3", 100, 15, null);

        actor.vaultComponent.AddMotherBoard(motherBoard01);
        actor.vaultComponent.AddMotherBoard(motherBoard02);
        actor.vaultComponent.AddMotherBoard(motherBoard03);

        List<MotherBoard> tempList = actor.vaultComponent.GetMotherBoards();

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

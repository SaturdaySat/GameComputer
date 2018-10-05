using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        ActorRoot actor = new ActorRoot();
        actor.Init();
        ActorHelper.GetInstance().SetHostActor(actor);

        //创建电脑
        CPU cpu = new CPU(ComputerPartType.CPU, 1001, 1001, "I9-10000k", "非常牛逼", 100, 50, 100, "LGA2066", 10.0f);
        RAM ram = new RAM(ComputerPartType.RAM, 1001, 1001, "Tizen-4266", "地表最强你懂吗", 100, 5000, 50, "DDR3", 4266, 128);
        VideoCard videoCard = new VideoCard(ComputerPartType.VideoCard, 1001, 1001, "RTX 8000", "火星最强你懂吗", 100, 8000, 500, 1800, 48);

        MotherBoard motherBoard = new MotherBoard(ComputerPartType.MotherBoard, 2001, 2001, "ASAS-X10086", "特别牛逼", 100, 15, 20, cpu, ram, videoCard);

        DiskDriver disk = new DiskDriver(ComputerPartType.Disk, 1001, 1001, "Intel X4800 REV", "这个不能说", 100, 88000, 20, true, 380, 0, DiskDriver.DiskConnectorType.PCIE_NVME);
        Power powerSupply = new Power(ComputerPartType.Power, 1001, 1001, "EVGA 1600AX", "老六炸过这个玩意", 100, 3500, -1600, -1600, -1800, 50, 100);

        ComputerCase comCase = new ComputerCase();
        comCase.Init();
        comCase.MotherBoardSlot.Part = motherBoard;
        actor.maingameLinkerComponent.ComputerCase = comCase;

        MotherBoard motherBoard01 = new MotherBoard(ComputerPartType.MotherBoard, 2002, 2002, "ASAS-X10087", "特别牛逼+1", 100, 15, 20, null, null, null);
        MotherBoard motherBoard02 = new MotherBoard(ComputerPartType.MotherBoard, 2003, 2003, "ASAS-X10088", "特别牛逼+2", 100, 15, 20, null, null, null);
        MotherBoard motherBoard03 = new MotherBoard(ComputerPartType.MotherBoard, 2004, 2004, "ASAS-X10089", "特别牛逼*3", 100, 15, 20, null, null, null);

        actor.vaultComponent.AddMotherBoard(motherBoard01);
        actor.vaultComponent.AddMotherBoard(motherBoard02);
        actor.vaultComponent.AddMotherBoard(motherBoard03);

        List<MotherBoard> tempList = actor.vaultComponent.GetMotherBoards();

        EventManager.GetInstance().Init();
        UIManager.GetInstance().InitManager();

        UIManager.GetInstance().PushPanel(UIPanelPath.UI_PANEL_MAINGAME);

    }

    void OnDisable()
    {

    }

    void Update()
    {
        UIManager.GetInstance().UpateUI();
        ActorHelper.GetInstance().GetHostActor().Update();
    }


}

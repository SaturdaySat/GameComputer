using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameMainPanelWidgets{
	MotherBoard = 0,
	CPU = 1,
	RAM0 = 2,
	VideoCard = 3,
	Power = 4,
	Disk = 5,
	InfoPanel = 6,
}

public class GameMainPanel : UIBase {

    private GameObject infoPanel;

    private ActorRoot srcActor;
    private ComputerCase comCase;

    private GameObject m_Motherboard;
    private GameObject m_CPU;
    private GameObject m_RAM0;
    private GameObject m_VideoCard;
    private GameObject m_Power;
    private GameObject m_Disk;
    private GameObject m_InfoPanel;

    public override void Init()
    {
        base.Init();
        infoPanel = GetWidget((int)GameMainPanelWidgets.InfoPanel);
        infoPanel.SetActive(false);

        srcActor = ActorHelper.GetInstance().GetHostActor();
        if (srcActor == null)
            return;
        comCase = srcActor.maingameLinkerComponent.ComputerCase;

        m_Motherboard = GetWidget((int)GameMainPanelWidgets.MotherBoard);
        m_CPU = GetWidget((int)GameMainPanelWidgets.CPU);
        m_RAM0 = GetWidget((int)GameMainPanelWidgets.RAM0);
        m_VideoCard = GetWidget((int)GameMainPanelWidgets.VideoCard);
        m_Power = GetWidget((int)GameMainPanelWidgets.Power);
        m_Disk = GetWidget((int)GameMainPanelWidgets.Disk);
        m_InfoPanel = GetWidget((int)GameMainPanelWidgets.InfoPanel);

        m_Motherboard.SetActive(true);
        m_CPU.SetActive(true);
        m_RAM0.SetActive(true);
        m_VideoCard.SetActive(true);
        m_Power.SetActive(true);
        m_Disk.SetActive(true);
        m_InfoPanel.SetActive(false);

        m_Motherboard.GetComponent<Button>().onClick.AddListener(OnMotherBoardClick);

        AddListener();

        RefreshCase();
    }

    public override void UnInit()
    {
        base.UnInit();

        RmvListner();
    }


    private void AddListener()
    {
        EventManager.GetInstance().AddEventListener(EventName.Event_Computer_Slot_Click, OnSlotClick);
    }

    private void RmvListner()
    {
        EventManager.GetInstance().RmvEventListener(EventName.Event_Computer_Slot_Click, OnSlotClick);
    }

    public void RefreshCase()
    {
        if (srcActor == null || comCase == null)
        {
            CloseAllUI();
            return;
        }

        if (comCase.MotherBoardSlot.Part == null)
        {
            
        }
        else
        {
            
            //看主板上的槽位
            if (comCase.MotherBoardSlot.Part.Type == ComputerPartType.MotherBoard)
            {
                MotherBoard motherboard = (MotherBoard)comCase.MotherBoardSlot.Part;



            }

        }


    }


    private void CloseAllUI()
    {
        for (int i = (int)GameMainPanelWidgets.MotherBoard; i < (int)GameMainPanelWidgets.InfoPanel; i++)
        {
            GetWidget(i).gameObject.SetActive(false);
        }
    }

	private void OnMotherBoardClick()
	{
        SlotClickEventParam param = new SlotClickEventParam
        {
            part = comCase.MotherBoardSlot.Part
        };
        EventManager.GetInstance().SendEvent(EventName.Event_Computer_Slot_Click, param);
	}

	private void OnCPUClick()
	{
	
	}

	private void OnRAMClick()
	{
	
	}

	private void OnVideoCardClick()
	{
	
	}

	private void OnPowerButtonClick()
	{
		
	}

	private void OnDiskClick()
	{

	}

    private void OnSlotClick(EventParam param)
    {

        print("abc");
        if (param.GetType() != typeof(SlotClickEventParam))
        {
            return;
        }
        ComputerPartBase part = ((SlotClickEventParam)param).part;
        if (part == null)
        {
            return;
        }

        m_InfoPanel.SetActive(true);

        switch (part.Type)
        {
            case ComputerPartType.None:
                break;
            case ComputerPartType.MotherBoard:
                break;
            case ComputerPartType.CPU:
                break;
            case ComputerPartType.RAM:
                break;
            case ComputerPartType.VideoCard:
                break;
            case ComputerPartType.Power:
                break;
            case ComputerPartType.Disk:
                break;
            case ComputerPartType.Max:
                break;
            default:
                break;
        }


    }

}

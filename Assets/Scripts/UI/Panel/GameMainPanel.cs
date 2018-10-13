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
    ItemContent = 7,
    ItemTemplate = 8,
    BagPanel = 9,
    InfoPanelBagItem = 10,
}

public class GameMainPanel : UIBase {
    private ActorRoot srcActor;
    private ComputerCase comCase;

    private GameObject m_Motherboard;
    private GameObject m_CPU;
    private GameObject m_RAM0;
    private GameObject m_VideoCard;
    private GameObject m_Power;
    private GameObject m_Disk;
    private GameObject m_InfoPanel;
    private GameObject m_BagPanel;
    private GameObject m_InfoPanelBagItem;

    private ComputerPartBase m_selectComputerPart;
    private ComputerPartBase m_selectBagPart;
    private int m_selectBagIndex;

    public override void Init()
    {
        base.Init();
        Clear();
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
        m_BagPanel = GetWidget((int)GameMainPanelWidgets.BagPanel);
        m_InfoPanelBagItem = GetWidget((int)GameMainPanelWidgets.InfoPanelBagItem);

        m_Motherboard.SetActive(true);
        m_CPU.SetActive(true);
        m_RAM0.SetActive(true);
        m_VideoCard.SetActive(true);
        m_Power.SetActive(true);
        m_Disk.SetActive(true);
        m_InfoPanel.SetActive(false);   //信息显示面板
        m_BagPanel.SetActive(false);
        m_InfoPanelBagItem.SetActive(false);

        m_Motherboard.GetComponent<Button>().onClick.AddListener(OnMotherBoardClick);

        AddListener();

        RefreshCase();
    }

    public override void UnInit()
    {
        base.UnInit();
        Clear();
        RmvListner();
    }

    private void AddListener()
    {
        EventManager.GetInstance().AddEventListener(EventName.Event_Computer_Slot_Click, OnSlotClick);
        EventManager.GetInstance().AddEventListener(EventName.Event_Bag_Item_Click, OnBagItemClick);
        EventManager.GetInstance().AddEventListener(EventName.Event_Open_BagPanel, OnOpenBagPanel);
        EventManager.GetInstance().AddEventListener(EventName.Event_Close_BagPanel, OnCloseBagPanel);
        EventManager.GetInstance().AddEventListener(EventName.Event_Close_InfoPanel, OnCloseInfoPanel);
    }

    private void RmvListner()
    {
        EventManager.GetInstance().RmvEventListener(EventName.Event_Computer_Slot_Click, OnSlotClick);
        EventManager.GetInstance().RmvEventListener(EventName.Event_Bag_Item_Click, OnBagItemClick);
        EventManager.GetInstance().RmvEventListener(EventName.Event_Open_BagPanel, OnOpenBagPanel);
        EventManager.GetInstance().RmvEventListener(EventName.Event_Close_BagPanel, OnCloseBagPanel);
        EventManager.GetInstance().RmvEventListener(EventName.Event_Close_InfoPanel, OnCloseInfoPanel);
    }


    private void Clear()
    {
        srcActor = null;
        comCase = null;

        m_Motherboard = null;
        m_CPU = null;
        m_RAM0 = null;
        m_VideoCard = null;
        m_Power = null;
        m_Disk = null;
        m_InfoPanel = null;
        m_BagPanel = null;

        m_selectComputerPart = null;
        m_selectBagPart = null;
        m_selectBagIndex = -1;
}

    //刷新显示 根据每个部件，显示对应的图片资源
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
        if (param.GetType() != typeof(SlotClickEventParam))
        {
            return;
        }
        ComputerPartBase part = ((SlotClickEventParam)param).part;

        if (part == null)
        {
            return;
        }
        m_selectComputerPart = part;
        switch (part.Type)
        {
            case ComputerPartType.None:
                break;
            case ComputerPartType.MotherBoard:
                ShowMotherBoardInfo((MotherBoard)part);
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

    private void OpenInfoPanel()
    {
        if (m_InfoPanel)
        {
            m_InfoPanel.SetActive(true);
        }
    }

    //关闭信息面板
    private void CloseInfoPanel()
    {
        if (m_InfoPanel)
        {
            m_InfoPanel.SetActive(false);
        }
    }

    private void OnBagItemClick(EventParam param)
    {
        if (param == null)
            return;
        if(param.GetType() != typeof(BagItemClickEventParam))
        {
            return;
        }
        ComputerPartBase part = ((BagItemClickEventParam)param).part;
        m_selectBagPart = part;
        m_selectBagIndex = ((BagItemClickEventParam)param).index;
        RefreshBag(part.Type);
        RefreshBagInfoPanel();
        Debug.Log(part.PartName+" "+m_selectBagIndex);
    }

    private void RefreshBagInfoPanel()
    {
        if (m_selectBagPart == null || m_selectBagIndex < 0)
        {
            m_InfoPanelBagItem.SetActive(false);
            return;
        }

        m_InfoPanelBagItem.SetActive(true);
        Text textTitle = m_InfoPanelBagItem.transform.Find("textTitle").GetComponent<Text>();
        textTitle.text = m_selectBagPart.PartName;

        Text textDesc = m_InfoPanelBagItem.transform.Find("textDesc").GetComponent<Text>();
        textDesc.text = m_selectBagPart.PartDesc;
    }

    private void ShowMotherBoardInfo(MotherBoard motherBoard)
    {
        if (motherBoard == null)
        {
            return;
        }

        OpenInfoPanel();
        RefreshInfoPanel(motherBoard);

        //背包内容
        RefreshBag(motherBoard.Type);
    }

    //刷新面板信息
    private void RefreshInfoPanel(ComputerPartBase part)
    {
        Image iconImage = m_InfoPanel.transform.Find("imgIcon").GetComponent<Image>();
        iconImage.sprite = Resources.Load<Sprite>(ArtPath.ART_UI_ICON + part.PartIcon);

        Text textTitle = m_InfoPanel.transform.Find("textTitle").GetComponent<Text>();
        textTitle.text = part.PartName;

        Text textDesc = m_InfoPanel.transform.Find("textDesc").GetComponent<Text>();
        textDesc.text = part.PartDesc;
    }

    private Transform CreateBagItem(int index)
    {
        GameObject template = GetWidget((int)GameMainPanelWidgets.ItemTemplate);
        if(template == null)
        {
            return null;
        }
        GameObject newBagItem = Instantiate(template, template.transform.parent);
        newBagItem.name = "bagItem" + index;
        newBagItem.transform.localScale = template.transform.localScale;
        newBagItem.transform.position = template.transform.position;
        newBagItem.transform.rotation = template.transform.rotation;
        return newBagItem.transform;
    }

    private void RefreshBagItem(Transform bagItem, ComputerPartBase part, int index)
    {
        bagItem.gameObject.SetActive(true);
        Image imgIcon = bagItem.Find("imgIcon").GetComponent<Image>();
        imgIcon.sprite = Resources.Load<Sprite>(ArtPath.ART_UI_ICON + part.PartIcon);
        Text textName = bagItem.Find("textName").GetComponent<Text>();
        textName.text = part.PartName;

        //添加Param
        BagButtonEvent buttonEvent = bagItem.GetComponent<BagButtonEvent>();
        BagItemClickEventParam param = new BagItemClickEventParam
        {
            index = index,
            part = part
        };
        buttonEvent.SetParam(param);
    }

    private void RefreshBag(ComputerPartType type)
    {
        //先获取现在这个种类的东西
        List<ComputerPartBase> itemList = srcActor.vaultComponent.GetComputerPartList(type);
        if(itemList == null)
        {
            return;
        }
        GameObject itemContent = GetWidget((int)GameMainPanelWidgets.ItemContent);
        if(itemContent == null)
        {
            return;
        }
        int itemCount = itemContent.transform.childCount - 1;
        int maxCount = itemCount > itemList.Count ? itemCount : itemList.Count;

        //先找一个Item，如果没有则创建一个新的
        for (int index = 0; index < maxCount; index++)
        {
            Transform bagItem = itemContent.transform.Find("bagItem" + index);
            if(bagItem == null)
            {
                //创建一个新的
                bagItem = CreateBagItem(index);
                if(bagItem == null)
                {
                    return;
                }
            }
            if(index<=itemList.Count)
            {
                //代表现在还有需要显示的内
                RefreshBagItem(bagItem, itemList[index], index);
            }
            else
            {
                //现在没有需要显示的内容，但是有多余的button，需要隐藏
                bagItem.gameObject.SetActive(false);
            }
            bagItem.transform.Find("imgSelect").gameObject.SetActive(m_selectBagIndex == index);
        }
    }

    private void OnOpenBagPanel(EventParam param)
    {
        if (m_BagPanel)
            m_BagPanel.SetActive(true);
    }

    private void OnCloseBagPanel(EventParam param)
    {
        if (m_BagPanel)
            m_BagPanel.SetActive(false);
        if (m_InfoPanelBagItem)
            m_InfoPanelBagItem.SetActive(false);

        m_selectBagIndex = -1;
        m_selectBagPart = null;
    }

    private void OnCloseInfoPanel(EventParam param)
    {
        CloseInfoPanel();
    }

}

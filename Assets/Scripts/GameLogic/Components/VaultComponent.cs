using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VaultComponent : BaseComponent {
    private Dictionary<int, MotherBoard> motherBoardsDict;


    public override void Init()
    {
        base.Init();
        motherBoardsDict = new Dictionary<int, MotherBoard>();
    }

    public bool AddMotherBoard(MotherBoard motherBoard)
    {
        if (motherBoard == null)
        {
            return false;
        }
        motherBoardsDict.Add(motherBoard.PartId, motherBoard);
        return true;
    }

    public MotherBoard GetMotherBoard(int partId)
    {
        MotherBoard motherBoard = null;
        motherBoardsDict.TryGetValue(partId, out motherBoard);
        return motherBoard;
    }

    public List<MotherBoard> GetMotherBoards()
    {
        return new List<MotherBoard>(motherBoardsDict.Values);
    }

    public List<ComputerPartBase> GetComputerPartList(ComputerPartType type)
    {
        List<ComputerPartBase> itemList = new List<ComputerPartBase>();

        switch (type)
        {
            case ComputerPartType.None:
                break;
            case ComputerPartType.MotherBoard:
                itemList = GetMotherBoards().Cast<ComputerPartBase>().ToList<ComputerPartBase>();
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

        return itemList;

    }


}

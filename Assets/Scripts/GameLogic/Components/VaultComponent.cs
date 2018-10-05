using System.Collections;
using System.Collections.Generic;
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



}

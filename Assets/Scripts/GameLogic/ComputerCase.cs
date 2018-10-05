using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCase {

	public ComputerPartSlot MotherBoardSlot;
    public ComputerPartSlot PowerSlot;
    public ComputerPartSlot DiskSlot;

	public void Init()
	{
		MotherBoardSlot = new ComputerPartSlot ();
		PowerSlot = new ComputerPartSlot ();
		DiskSlot = new ComputerPartSlot ();

		MotherBoardSlot.Init (ComputerPartType.MotherBoard, null);
		PowerSlot.Init (ComputerPartType.Power, null);
		DiskSlot.Init (ComputerPartType.Disk, null);
	}

    public int GetScore()
    {

        //TODO
        return 0;
    }
}

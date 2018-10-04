using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPartBase {
	public ComputerPartType Type;
    public int PartId;
    public int PariIcon;
    public string PartName;
    public int PartDesc;
    public int Durability;
    public int Price;
}


public class MotherBoard : ComputerPartBase{
	ComputerPartSlot CPUSlot;
	ComputerPartSlot RAMSlot;
	ComputerPartSlot VideoCardSlot;

	public void Init()
	{
		CPUSlot = new ComputerPartSlot ();
		RAMSlot = new ComputerPartSlot ();
		VideoCardSlot = new ComputerPartSlot ();

		CPUSlot.Init (ComputerPartType.CPU, null);
		RAMSlot.Init (ComputerPartType.RAM, null);
		VideoCardSlot.Init (ComputerPartType.VideoCard, null);
	}
}
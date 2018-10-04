using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPartBase {
	public ComputerPartType Type;
    public int PartId;
    public int PartIcon;
    public string PartName;
    public string PartDesc;
    public int Durability;
    public int Price;

    public ComputerPartBase(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price)
    {
        Type = _Type;
        PartId = _PartId;
        PartIcon = _PartIcon;
        PartName = _PartName;
        PartDesc = _PartDesc;
        Durability = _Durability;
        Price = _Price;
    }
}

public class CPU : ComputerPartBase
{
    public string SocketType;
    public float Frequency;    //hz 

    public CPU(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, string _SocketType, float _Frequency) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price)
    {
        SocketType = _SocketType;
        Frequency = _Frequency;
    }
}


public class MotherBoard : ComputerPartBase{
	ComputerPartSlot CPUSlot;
	ComputerPartSlot RAMSlot;
	ComputerPartSlot VideoCardSlot;

    public MotherBoard(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, CPU _Cpu) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price)
    {
        Init();
        CPUSlot.Part = _Cpu;
    }

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
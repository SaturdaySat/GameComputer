using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPartBase
{
    public ComputerPartType Type;
    public int PartId;
    public int PartIcon;
    public string PartName;
    public string PartDesc;
    public int Durability;
    public int Price;
    public int PowerConsumption;

    public ComputerPartBase(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption)
    {
        Type = _Type;
        PartId = _PartId;
        PartIcon = _PartIcon;
        PartName = _PartName;
        PartDesc = _PartDesc;
        Durability = _Durability;
        Price = _Price;
        PowerConsumption = _PowerConsumption;
    }
}

public class CPU : ComputerPartBase
{
    public string SocketType;
    public float Frequency;

    public CPU(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, string _SocketType, float _Frequency) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {
        SocketType = _SocketType;
        Frequency = _Frequency;
    }
}


public class MotherBoard : ComputerPartBase
{
    ComputerPartSlot CPUSlot;
    ComputerPartSlot RAMSlot;
    ComputerPartSlot VideoCardSlot;

    public MotherBoard(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, CPU _Cpu, RAM _RAM, VideoCard _VideoCard) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {
        Init();
        CPUSlot.Part = _Cpu;
        RAMSlot.Part = _RAM;
        VideoCardSlot.Part = _VideoCard;
    }

    public void Init()
    {
        CPUSlot = new ComputerPartSlot();
        RAMSlot = new ComputerPartSlot();
        VideoCardSlot = new ComputerPartSlot();

        CPUSlot.Init(ComputerPartType.CPU, null);
        RAMSlot.Init(ComputerPartType.RAM, null);
        VideoCardSlot.Init(ComputerPartType.VideoCard, null);
    }
}

public class RAM : ComputerPartBase
{

    public string Version; // ddr3 4
    public float Frequency; // 1033 1333 1600 1866 2133 2400 2666 2866 3000 3333 3666 3866 4233
    public int Volume; // 1g 2g 4g 8g 16g     

    public RAM(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, string _Version, float _Frequency, int _Volume) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {
        Version = _Version;
        Frequency = _Frequency;
        Volume = _Volume;

    }

}

public class VideoCard : ComputerPartBase
{

    public float Frequency;
    public int Volume;

    public VideoCard(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, float _Frequency, int _Volume) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {
        Frequency = _Frequency;
        Volume = _Volume;

    }

}

public class Power : ComputerPartBase
{

    public int OutputWatte;
    public int MaxOutputWatte;
    public float Frequency;

    public int BoomPrecent;

    public Power(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, int _OutputWatte, int _MaxOutputWatte, float _Frequency, int _BoomPrecent) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {
        OutputWatte = _OutputWatte;
        MaxOutputWatte = _MaxOutputWatte;
        Frequency = _Frequency;
        BoomPrecent = _BoomPrecent;
    }


}



public class DiskDriver : ComputerPartBase
{

    public enum DiskConnectorType
    {
        SATA,
        U2,
        PCIE_NVME,
        NGFF_SATA,
        NGFF_NVME,

    }


    public bool IsSSD;
    public int Volume;
    public int RPM;
    public DiskConnectorType diskConnectorType;

    public DiskDriver(ComputerPartType _Type, int _PartId, int _PartIcon, string _PartName, string _PartDesc, int _Durability, int _Price, int _PowerConsumption, bool _IsSSD, int _Volume, int _RPM, DiskConnectorType _DiskConnectorType) : base(_Type, _PartId, _PartIcon, _PartName, _PartDesc, _Durability, _Price, _PowerConsumption)
    {

        IsSSD = _IsSSD;
        Volume = _Volume;
        RPM = _RPM;
        diskConnectorType = _DiskConnectorType;

    }

}
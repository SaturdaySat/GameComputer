using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComputerPartType
{
	None,

	MotherBoard,
	CPU,
	RAM,
	VideoCard,
	Power,
	Disk,

	Max,
}

public class ComputerPartSlot{
	public ComputerPartType Type;	
	public ComputerPartBase Part;

	public ComputerPartSlot(){
	}

	public void Init(ComputerPartType _Type, ComputerPartBase _Part){
		Type = _Type;
		Part = _Part;
	}

}


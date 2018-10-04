using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLinkerComponent : BaseComponent{
	private ComputerCase computerCase;
	public ComputerCase ComputerCase
	{
		set
		{
			computerCase = value;
		}
		get
		{
			return computerCase;
		}

	}

}

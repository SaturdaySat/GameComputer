using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorRoot {

	List<BaseComponent> components;
	public MainGameLinkerComponent maingameLinkerComponent;

    public void Init()
    {
        components = new List<BaseComponent>();

        maingameLinkerComponent = new MainGameLinkerComponent();
        maingameLinkerComponent.Init();
        components.Add(maingameLinkerComponent);

        ComputerCase comCase = new ComputerCase();
        comCase.Init();
        maingameLinkerComponent.ComputerCase = comCase;
    }


    // Update is called once per frame
    public void Update () {
		foreach (var item in components)
		{
			item.Update ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorRoot : MonoBehaviour {

	List<BaseComponent> components;
	public MainGameLinkerComponent maingameLinkerComponent;

	// Use this for initialization
	void Start () {
		components = new List<BaseComponent> ();

		maingameLinkerComponent = new MainGameLinkerComponent ();
		maingameLinkerComponent.Init ();
		components.Add (maingameLinkerComponent);

		ComputerCase comCase = new ComputerCase ();
		comCase.Init ();
		maingameLinkerComponent.ComputerCase = comCase;
		ActorHelper.GetInstance ().SetHostActor (this);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var item in components)
		{
			item.Update ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorRoot {

	List<BaseComponent> components;
	public MainGameLinkerComponent maingameLinkerComponent;
    public VaultComponent vaultComponent;

    public void Init()
    {
        components = new List<BaseComponent>();

        maingameLinkerComponent = new MainGameLinkerComponent();
        maingameLinkerComponent.Init();

        vaultComponent = new VaultComponent();
        vaultComponent.Init();

        components.Add(maingameLinkerComponent);
        components.Add(vaultComponent);
    }


    // Update is called once per frame
    public void Update () {
		foreach (var item in components)
		{
			item.Update ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorHelper : Singleton<ActorHelper>{

	private ActorRoot hostActor;

	public ActorRoot GetHostActor()
	{
		return hostActor;
	}

	public void SetHostActor(ActorRoot _hostActor)
	{
		this.hostActor = _hostActor;
	}
}

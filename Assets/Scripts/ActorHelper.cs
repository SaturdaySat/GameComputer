using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////
//角色管理
//////////////////////////////////////////
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

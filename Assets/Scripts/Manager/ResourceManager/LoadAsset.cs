using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadAsset{

	/// <summary>
	/// 资源信息
	/// </summary>
	public ResourceRequest request;

	public string AssetName;

	public Type AssetType;

	/// <summary>
	/// 是否加载完成 
	/// </summary>
	/// <value><c>true</c> if this instance is done; otherwise, <c>false</c>.</value>
	public bool IsDone{
		get{return request!=null&&request.isDone;} 
	}

	public object GetAsset{
		get{ 
			if (request == null) {
				return null;
			}
			return request.asset;
		}
	}

	public void LoadAsync(){
		this.request = Resources.LoadAsync (AssetName, AssetType);
	}

	/// <summary>
	/// 回调的集合
	/// </summary>
	public List<IResourceListener> Listeners;

	public void AddListener(IResourceListener listener){
		if (Listeners == null) {
			Listeners = new List<IResourceListener> ();
		}
		if (Listeners.Contains (listener)) {
			return;
		}
		Listeners.Add (listener);
	}

	public string Info(){
		return this.IsDone + " " + this.AssetName+" "+this.AssetType;
	}
}

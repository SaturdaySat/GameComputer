using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 资源管理类
/// </summary>
public class ResourceManager : Singleton<ResourceManager> {

	/// <summary>
	/// 已经加载的资源字典
	/// </summary>
	private Dictionary<string, LoadAsset> nameAssetDict;

	/// <summary>
	/// 正在加载的资源列表
	/// </summary>
	private List<LoadAsset> loadingList;

	/// <summary>
	/// 等待加载的资源队列
	/// </summary>
	private Queue<LoadAsset> waitingQue;

    public void InitManager()
    {
        nameAssetDict = new Dictionary<string, LoadAsset>();
        loadingList = new List<LoadAsset>();
        waitingQue = new Queue<LoadAsset>();
    }

	public void Update(){
		//看加载队列里面的是否加载完成，如果加载完成移动到加载完成后的字典并且回调所有的Listener
		if (loadingList.Count > 0) {
			for (int i = 0; i < loadingList.Count; i++) {
				if (loadingList [i].IsDone) {
					LoadAsset asset = loadingList [i];
					for (int j = 0; j < asset.Listeners.Count; j++) {
						asset.Listeners [j].OnLoaded (asset.AssetName, asset.GetAsset);
					}
					loadingList.Remove (asset);
					nameAssetDict.Add (asset.AssetName, asset);
				}
			}
		}

		while (waitingQue.Count > 0 && loadingList.Count<5) {
			LoadAsset asset = waitingQue.Dequeue ();
			loadingList.Add (asset);
			asset.LoadAsync ();
		}

	}

	public void Load(string assetName, Type assetType, IResourceListener listener){
		//如果已完成加载
		if (nameAssetDict.ContainsKey (assetName)) {
			LoadAsset asset = nameAssetDict [assetName];
			listener.OnLoaded (asset.AssetName,asset.GetAsset);
			return;
		} else {//如果没有完成加载 那么就异步加载该资源
			LoadAsync (assetName, assetType, listener);
		}
	}

	private void LoadAsync(string assetName, Type assetType, IResourceListener listener){
		//如果该资源在加载中队列，则在该资源的回调列表中添加此Listener
		foreach(LoadAsset item in loadingList){
			if (item.AssetName == assetName) {
				item.AddListener (listener);
				return;
			}
		}
		//如果该资源在等待列表中
		foreach(LoadAsset item in waitingQue){
			if (item.AssetName == assetName) {
				item.AddListener (listener);
				return;
			}
		}
		//如果该资源未在任何已存在的列表中
		LoadAsset asset = new LoadAsset();
		asset.AssetName = assetName;
		asset.AssetType = assetType;
		asset.AddListener (listener);
		waitingQue.Enqueue (asset);
	}

	public object GetAsset(string assetName){
		LoadAsset loadasset = null;
		nameAssetDict.TryGetValue (assetName, out loadasset);
		return loadasset.GetAsset;
	}

	public void ReleaseAsset(string assetName){
		if (nameAssetDict.ContainsKey (assetName)) {
			nameAssetDict [assetName] = null;
			nameAssetDict.Remove (assetName);
		}
	}

	public void ReleaseAll(){
		Resources.UnloadUnusedAssets ();
		GC.Collect ();
	}
}

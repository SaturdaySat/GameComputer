using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceListener {

	/// <summary>
	///加载完成时的回调 
	/// </summary>
	/// <param name="asset">Asset.</param>
	void OnLoaded(string assetName, object asset);
}

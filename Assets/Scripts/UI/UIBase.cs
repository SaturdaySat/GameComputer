using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class UIBase : MonoBehaviour {

	public GameObject[] widget;

	public virtual void Init(){
	}

	public virtual void UnInit()
	{
	}

	public virtual void OnShowing(){
		CanvasGroup canGroup = this.GetComponent<CanvasGroup> ();
		canGroup.alpha = 1;
		canGroup.blocksRaycasts = true;
		canGroup.interactable = true;
		this.gameObject.SetActive (true);
	}

	public virtual void OnShowed(){
	}

	public virtual void OnClosing(){
		CanvasGroup canGroup = this.GetComponent<CanvasGroup> ();
		canGroup.alpha = 0;
		canGroup.blocksRaycasts = false;
		canGroup.interactable = false;
	}

	public virtual void OnClosed(){
	}

	public virtual void OnPause(){
	}

	public virtual void OnResume(){
	}

	public virtual void Update(){
	}

	public virtual GameObject GetWidget(int index){
		return widget [index];
	}
}

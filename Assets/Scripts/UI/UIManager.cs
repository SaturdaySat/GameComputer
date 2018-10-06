using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>{

	private Dictionary<string, UIBase> uiDict;
	private Stack<UIBase> uiStack;

	private Transform canvasTransform;
	private Transform CanvasTransform{
		get{ 
			if (canvasTransform == null)
			{
				canvasTransform = GameObject.Find ("Canvas").transform;
			}
			return canvasTransform;
		}
	}

	public void InitManager(){
		if (uiDict == null)
			uiDict = new Dictionary<string, UIBase> ();
		if (uiStack == null)
			uiStack = new Stack<UIBase> ();
	}

	public void UpateUI()
	{
		foreach (var ui in uiDict.Values)
		{
			ui.Update ();
		}
	}


	private UIBase GetPanel(string uiPath)
	{
		UIBase uiPanel;
		uiDict.TryGetValue (uiPath, out uiPanel);
        if (uiPanel == null)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load<GameObject>(uiPath));
            obj.transform.SetParent(CanvasTransform, false);
            uiPanel = obj.GetComponent<UIBase>();
            uiPanel.Init();
            uiDict.Add(uiPath, uiPanel);
        }
		return uiPanel;
	}

	public void PushPanel(string uiPath)
	{
		if (uiStack.Count > 0)
		{
			UIBase topUI = uiStack.Peek ();
			topUI.OnPause ();
		}
		UIBase uiPanel = GetPanel (uiPath);
		uiPanel.OnShowing ();
		uiPanel.OnShowed ();
		uiStack.Push (uiPanel);
	}

	public void PopPanel(string uiPath)
	{
		if (uiStack.Count <= 0)
			return;
		UIBase topPanel = uiStack.Pop ();
		topPanel.OnClosing ();
		topPanel.OnClosed ();
		if (uiStack.Count <= 0)
			return;
		UIBase nextPanel = uiStack.Peek ();
		nextPanel.OnResume ();
	}
}
	

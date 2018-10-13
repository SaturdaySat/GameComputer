using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BagButtonEvent : MonoBehaviour {

    private BagItemClickEventParam param;

	void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClickEvent);

    }

    public void Clear()
    {
        param = new BagItemClickEventParam
        {
            part = null
        };
    }

    public void SetParam(BagItemClickEventParam param)
    {
        this.param = param;
    }


    private void OnClickEvent()
    {
        EventManager.GetInstance().SendEvent(EventName.Event_Bag_Item_Click, param);
    }


	
}

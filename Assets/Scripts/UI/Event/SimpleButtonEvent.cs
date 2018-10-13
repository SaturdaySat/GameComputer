using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SimpleButtonEvent : MonoBehaviour
{
    [SerializeField]
    private EventName eventName;

    // Use this for initialization
    void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClickEvent);
    }

    private void OnClickEvent()
    {
        EventManager.GetInstance().SendEvent(eventName, new EventParam());
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class item : MonoBehaviour {
    public string _name {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }
        
    public string description
    {
        get
        {
            return Description;
        }
        set
        {
            Description = value;
        }
    }
    public int count
    {
        get
        {
            return Count;
        }
        set
        {
            Count = value;
        }
    }
    public int id
    {
        get
        {
            return Id;
        }
        set
        {
            Id = value;
        }
    }

    private string Name="";
    private string Description = "";
    private int Count=1;
    private gameItem items;
    private int Id;
    private Text text;

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("itemDescription").GetComponent<Text>();
        addEventTrigger(transform,EventTriggerType.PointerEnter,MouseEnter);
        addEventTrigger(transform,EventTriggerType.PointerExit,MouseExit);
    }
    public static void addEventTrigger(Transform transform, EventTriggerType eventType, UnityAction<BaseEventData> myFunction)
    {
        EventTrigger eventTri = transform.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;

        entry.callback.AddListener(myFunction);
        eventTri.triggers.Add(entry);
    }

    public void MouseEnter(BaseEventData data)
    {
        print("onmouseenter");
        text.text = Description+"数量"+count;
        
    }
    public void MouseExit(BaseEventData data)
    {
        print("mouseOut");
        text.text = "";
    }

}

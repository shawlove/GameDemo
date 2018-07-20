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
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
        set
        {
            sprite = value;
        }
    }
    public string Ss
    {
        get
        {
            return ss;
        }
        set
        {
            ss = value;
        }
    }
    public int PlayerPrice
    {
        get
        {
            return playerPrice;
        }
        set
        {
            playerPrice = value;
        }
    }
    public int TradePrice
    {
        get
        {
            return tradePrice;
        }
        set
        {
            tradePrice = value;
        }
    }
    public bool IsSelect
    {
        get
        {
            return isSelect;
        }
        set
        {
            isSelect = value;
        }
    }
    private string ss;
    private string Name="";
    private string Description = "";
    private int Count=1;
    //private gameItem items;
    private int Id;
    private int playerPrice;
    private int tradePrice;
    private Sprite sprite;

    private GameObject playerUI;
    private GameObject trade;
    private Text text;
    private Text traderText;
    private Text playerText;
    private GameObject _traderItems;
    private GameObject _playerItems;
    private GameObject _bagItems;
    private bool isSelect=false;
    private Image image;

    void Start()
    {
        playerUI = GameObject.Find("PlayerUI");
        trade = GameObject.Find("Trade");
        _bagItems=playerUI.transform.Find("Bag/Items/Viewport/Content").gameObject;
        text = playerUI.transform.Find("Bag/Description/Viewport/Content/Text").gameObject.GetComponent<Text>();
        traderText = trade.transform.Find("Trader/TDescription/Viewport/Content/Text").gameObject.GetComponent<Text>();
        playerText= trade.transform.Find("Trader/PDescription/Viewport/Content/Text").gameObject.GetComponent<Text>();
        _traderItems = trade.transform.Find("Trader/TraderItems/Viewport/Content").gameObject;
        _playerItems = trade.transform.Find("Trader/PlayerItems/Viewport/Content").gameObject;
        addEventTrigger(transform,EventTriggerType.PointerEnter,MouseEnter);
        addEventTrigger(transform,EventTriggerType.PointerExit,MouseExit);
        addEventTrigger(transform, EventTriggerType.PointerClick, MouseClick);
        image = GetComponent<Image>();
        image.sprite = sprite;
    }

    void Update()
    {
        foreach (gameItem._item it in gameItem.bag)
        {
            if (it.Id==Id)
            {
                Count = it.Count;
            }
        }
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
        if (ss.Equals("Player"))
        {
            text.text = Description + "数量" + count;
        }
        if (ss.Equals("TradeText"))
        {
            traderText.text = Description+"价格"+tradePrice;
        }
        if (ss.Equals("PlayerText"))
        {
            playerText.text = Description+"数量"+count+"卖出价"+playerPrice;
        }
        
    }
    public void MouseExit(BaseEventData data)
    {
        if (ss.Equals("Player"))
        {
            text.text = "";
        }
        if (ss.Equals("TradeText"))
        {
            traderText.text = "";
        }
        if (ss.Equals("PlayerText"))
        {
            playerText.text = "";
        }
    }

    public void MouseClick(BaseEventData data)
    {
        if (!isSelect)
        {
            image.color= Color.green;
            isSelect = true;
            if (ss.Equals("Player"))
            {
                foreach (item it in _bagItems.GetComponentsInChildren<item>())
                {
                    if (it.id != Id && it.IsSelect)
                    {
                        it.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        it.IsSelect = false;
                    }
                }
            }else if (ss.Equals("PlayerText"))
            {
                foreach (item it in _traderItems.GetComponentsInChildren<item>())
                {
                    if ( it.IsSelect)
                    {
                        it.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        it.IsSelect = false;
                    }
                }
                foreach (item it in _playerItems.GetComponentsInChildren<item>())
                {
                    if (it.id != Id && it.IsSelect)
                    {
                        it.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        it.IsSelect = false;
                    }
                }
            }
            else if (ss.Equals("TradeText"))
            {
                foreach (item it in _traderItems.GetComponentsInChildren<item>())
                {
                    if (it.id != Id && it.IsSelect)
                    {
                        it.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        it.IsSelect = false;
                    }
                }
                foreach (item it in _playerItems.GetComponentsInChildren<item>())
                {
                    if ( it.IsSelect)
                    {
                        it.GetComponent<Image>().color= new Color(1, 1, 1, 1);
                        it.IsSelect = false;
                    }
                }
            }

        }else
        {
            image.color = new Color(1,1,1,1);
        }
    }

}

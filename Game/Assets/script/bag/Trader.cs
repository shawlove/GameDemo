using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Trader : MonoBehaviour {

    public GameObject item;

    private GameObject prefab;
    private  GameObject F;
    private GameObject statusBar;
    private GameObject skillBar;
    private GameObject player;
    private fps_playerParamter paramter;
    private GameObject trader;
    private GameObject _traderItems;
    private GameObject _playerItems;
    private GameObject trade;
    private GameObject playerUI;
    private item _item;
    private fps_input input;
    private fps_FPInput fp;
    private Text money;
    private bool isF=false;
    //商品
    public Dictionary<int, gameItem._item> traderItems = new Dictionary<int, gameItem._item>();
    //回购商品
    //public Dictionary<int, gameItem._item> rePurchase = new Dictionary<int, gameItem._item>();


    void Start()
    {
        trade = GameObject.Find("Trade");
        playerUI = GameObject.Find("PlayerUI");
        player = GameObject.FindGameObjectWithTag("Player");
        F = playerUI.transform.Find("F").gameObject;
        statusBar =playerUI.transform.Find("StatusBar").gameObject;
        skillBar= playerUI.transform.Find("_SkillBar").gameObject;
        trader = trade.transform.Find("Trader").gameObject;
        money = trade.transform.Find("Trader/Money").gameObject.GetComponent<Text>();
        _traderItems = trade.transform.Find("Trader/TraderItems/Viewport/Content").gameObject;
        _playerItems = trade.transform.Find("Trader/PlayerItems/Viewport/Content").gameObject;
        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        input= GameObject.FindGameObjectWithTag("GameController").GetComponent<fps_input>();
        fp= GameObject.FindGameObjectWithTag("Player").GetComponent<fps_FPInput>();
        addTraderItem(1);
        addTraderItem(2);
    }
    void Update()
    {
        money.text = "余额：  "+paramter.money;
        nearTalk();
        if (paramter.isTrade)
        {
            foreach (gameItem._item it in gameItem.bag)
            {
                bool iscontain = false;
                foreach (item i in _playerItems.GetComponentsInChildren<item>())
                {
                    if (i.id == it.Id)
                    {
                        iscontain = true;
                    }
                }
                if (!iscontain)
                {
                    prefab = Instantiate(item);
                    _item = prefab.GetComponent<item>();
                    _item.id = it.Id;
                    _item.Sprite = it.sprite;
                    _item._name = it.Name;
                    _item.description = it.Description;
                    _item.count = it.Count;
                    _item.PlayerPrice = it.playerPrice;
                    _item.TradePrice = it.tradePrice;
                    _item.Ss = "PlayerText";
                    prefab.transform.SetParent(_playerItems.transform, false);
                }
            }
        }
    }

    private void nearTalk()
    {
        var distance = (player.transform.position - transform.position).magnitude;
        if (distance<5)
        {
            if (!isF)
            {
                F.SetActive(true);
                isF = true;
            }          
            if (input.GetButtonDown("F")&&paramter.isTrade==false)
            {
                paramter.isTrade = true;
                F.SetActive(false);
                isF = false;             
                openTrade();
            }
            if (input.GetButtonDown("Esc"))
            {
                paramter.isTrade = false;
                closeTrade();
                F.SetActive(true);
                isF = true;
            }
        }else
        {
            F.SetActive(false);
            isF = false;
        }
    }
    private void openTrade()
    {
        trader.SetActive(true);
        statusBar.SetActive(false);
        skillBar.SetActive(false);
        //商品展示
        foreach (KeyValuePair<int, gameItem._item> pair in traderItems)
        {
            prefab = Instantiate(item);
            _item = prefab.GetComponent<item>();
            _item.id = pair.Value.Id;
            _item.Sprite = pair.Value.sprite;
            _item._name = pair.Value.Name;
            _item.description = pair.Value.Description;
            _item.PlayerPrice = pair.Value.playerPrice;
            _item.TradePrice = pair.Value.tradePrice;
            _item.Ss = "TradeText";
            prefab.transform.SetParent(_traderItems.transform, false);
        }
        //玩家背包

    }
    private void closeTrade()
    {
        trader.SetActive(false);
        statusBar.SetActive(true);
        skillBar.SetActive(true);
        //删除所有商品
        for (int i=0;i<_traderItems.transform.childCount;i++)
        {
            Destroy(_traderItems.transform.GetChild(i).gameObject);
        }

    }
    public void addTraderItem(int i)
    {
        if (traderItems.ContainsKey(i))
        {
            foreach (KeyValuePair<int, gameItem._item> pair in traderItems)
            {
                if (pair.Key == i)
                {
                    pair.Value.Count++;
                }
            }
        }
        else
        {
            traderItems.Add(i,gameItem.cloneItem(gameItem._items[i]) );
        }
    }
    public void deleteTraderItem(int i)
    {
        if (traderItems.ContainsKey(i))
        {
            foreach (KeyValuePair<int, gameItem._item> pair in traderItems)
            {
                if (pair.Key == i)
                {
                    if (pair.Value.Count==1)
                    {
                        traderItems.Remove(i);
                    }else
                    {
                        pair.Value.Count--;
                    }
                    
                }
            }
        }
        else
        {
            print("物品不存在");
        }
    }
}

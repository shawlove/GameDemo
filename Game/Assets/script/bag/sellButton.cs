using UnityEngine;
using System.Collections;

public class sellButton : MonoBehaviour {

    private Animator anim;
    private GameObject playerUI;
    private GameObject trade;
    private GameObject _traderItems;
    private GameObject _playerItems;
    private fps_playerParamter paramter;
    void Start()
    {
        playerUI = GameObject.Find("PlayerUI");
        trade = GameObject.Find("Trade");
        _traderItems = trade.transform.Find("Trader/TraderItems/Viewport/Content").gameObject;
        _playerItems = trade.transform.Find("Trader/PlayerItems/Viewport/Content").gameObject;
        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        anim = GetComponent<Animator>();
    }

    public void Click()
    {
        foreach (item it in _traderItems.GetComponentsInChildren<item>())
        {
            if (it.IsSelect)
            {
                print("不能出售商品");
            }
        }
        foreach (item it in _playerItems.GetComponentsInChildren<item>())
        {
            if (it.IsSelect)
            {
                gameItem.deleteBagItem(it.id);
                paramter.money += it.PlayerPrice;   
            }
        }


        anim.SetTrigger("Highlighted");

    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerBag : MonoBehaviour
{
    public  GameObject obj;
    public GameObject bag;

    private gameItem item;
    private fps_playerParamter paramter;
    private new CanvasRenderer[] renderer;
    private GameObject prefab;
    private item Item;
    private item[] Items;
    private GameObject content;
    private GameObject playerUI;

    void Start()
    {
        playerUI = GameObject.Find("PlayerUI");
        
        //renderer = this.GetComponentsInChildren<CanvasRenderer>();
        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        // item= GameObject.FindGameObjectWithTag("GameController").GetComponent<gameItem>();
        content = playerUI.transform.Find("Bag/Items/Viewport/Content").gameObject;
        bag.SetActive(false);

    }


    void Update()
    {
        bagOpen();
    }

    private void bagOpen()
    {
        /*if (paramter.isBagOpen)
        {
            GetComponent<Canvas>().sortingOrder = 1;
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(1);
            }
        }
        else
        {
            GetComponent<Canvas>().sortingOrder = 0;
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(0);
            }
        }*/
        if (paramter.isBagOpen)
        {
            bag.SetActive(true);
        }else
        {
            bag.SetActive(false);
        }
        Items = content.GetComponentsInChildren<item>();

        

        foreach (gameItem._item i in gameItem.bag)
        {
            bool isContain = false;
            foreach (item it in Items)
            {
                if (it.id==i.Id)
                {
                    isContain = true;
                }
            }
            if (!isContain)
            {
                prefab = Instantiate(obj);
                Item = prefab.GetComponent<item>();
                Item.id = i.Id;
                Item.Sprite = i.sprite;
                Item._name = i.Name;
                Item.description = i.Description;
                Item.count = i.Count;
                Item.PlayerPrice = i.playerPrice;
                Item.TradePrice = i.tradePrice;
                Item.Ss = "Player";
                prefab.transform.SetParent(content.transform, false);
            }
           
       
        }

    }


}


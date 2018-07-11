using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerBag : MonoBehaviour
{
    public  GameObject obj;

    private gameItem item;
    private fps_playerParamter paramter;
    private new CanvasRenderer[] renderer;
    private GameObject prefab;
    private item Item;
    private item[] Items;
    private GameObject content;


    void Start()
    {
                
        renderer = this.GetComponentsInChildren<CanvasRenderer>();
        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        item= GameObject.FindGameObjectWithTag("GameController").GetComponent<gameItem>();
        content = GameObject.FindGameObjectWithTag("items");

    }


    void Update()
    {
        bagOpen();
    }

    private void bagOpen()
    {
        if (paramter.isBagOpen)
        {
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(1);
            }
        }
        else
        {
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(0);
            }
        }
        Items = content.GetComponentsInChildren<item>();

        

        foreach (gameItem._item i in item.bag)
        {
            if (Items.Length==0)
            {
                print("第一次");
                prefab = Instantiate(obj);
                Item = prefab.GetComponent<item>();
                Item.id = i.Id;
                Item._name = i.Name;
                Item.description = i.Description;
                Item.count = i.Count;
                prefab.transform.SetParent(content.transform,false);
            }
            foreach (item j in Items)
            {
                if (j.id ==i.Id)
                {
                    j.count = i.Count;
                }else
                {
                    print("实例化item");
                    prefab = Instantiate(obj);
                    Item = prefab.GetComponent<item>();
                    Item.id = i.Id;
                    Item._name = i.Name;
                    Item.description = i.Description;
                    Item.count = i.Count;
                    prefab.transform.SetParent(content.transform, false);
                }
            }
        }

    }


}


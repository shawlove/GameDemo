using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameItem : MonoBehaviour {

    public class _item
    {
        public string Name = "";
        public string Description = "";
        public int Count = 1;
        //public gameItem items;
        public int Id;
        public Sprite sprite;
        public int tradePrice;
        public int playerPrice;
    }
    public static Dictionary<int, _item> _items = new Dictionary<int, _item>();
    public static  List<_item> bag = new List<_item>();

    void Start () {
        Sprite[] sprites = Resources.LoadAll<Sprite>("picture/Icons/timg");
        addItem(1,"物体1","name:物体1 \n description:xxx \n ",sprites[0],1,5);
        addItem(2, "物体2", "name:物体2 \n description:xxx \n ",sprites[1],2,10);
    }
	
	
	void Update () {
	
	}
    private void addItem(int id, string n, string des,Sprite sp,int playerP,int tradeP)
    {
        if (_items.ContainsKey(id))
            _items[id] = new _item() { Name = n, Description = des ,Id=id,sprite=sp,playerPrice=playerP,tradePrice=tradeP};
        else
            _items.Add(id, new _item() { Name = n, Description = des ,Id=id, sprite = sp, playerPrice = playerP, tradePrice = tradeP });
    }
    public static _item cloneItem(_item item)
    {
        return new _item { Name = item.Name, Description = item.Description, Id = item.Id, sprite = item.sprite, Count = item.Count ,playerPrice=item.playerPrice,tradePrice=item.tradePrice};
    }
    public static void addBagItem(int i)
    {
        bool isContain = false;
        foreach (_item it in bag)
        {
            if (it.Id==i)
            {
                it.Count++;
                isContain = true;
            }
        }
        if (!isContain)
        {
            bag.Add(cloneItem(_items[i]));
        }
    }
    public static void deleteBagItem(int i)
    {
        foreach (_item it in bag)
        {
            if (it.Id == i)
            {
                if (it.Count==1)
                {
                    bag.Remove(it);
                }else
                {
                    it.Count--;
                }            
            }
        }    
    }
}



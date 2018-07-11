using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameItem : MonoBehaviour {

    public class _item
    {
        public string Name = "";
        public string Description = "";
        public int Count = 1;
        public gameItem items;
        public int Id;
    }
    public Dictionary<int, _item> _items = new Dictionary<int, _item>();
    public List<_item> bag = new List<_item>();

    void Start () {
        addItem(1,"物体1","name:物体1 \n description:xxx \n count： 1");
        addItem(2, "物体2", "name:物体2 \n description:xxx \n count： 1");
    }
	
	
	void Update () {
	
	}
    private void addItem(int id, string n, string des)
    {
        if (_items.ContainsKey(id))
            _items[id] = new _item() { Name = n, Description = des ,Id=id};
        else
            _items.Add(id, new _item() { Name = n, Description = des ,Id=id});
    }
    public void addBagItem(int i)
    {
        print("addBagItem");
        if (bag.Contains(_items[i]))
        {
            foreach (_item it in bag)
            {
                if (it == _items[i])
                {
                    it.Count++;
                }
            }
        }
        else
        {
            bag.Add(_items[i]);
        }
    }
    public void deleteBagItem(int i)
    {
        if (bag.Contains(_items[i]))
        {
            foreach (_item it in bag)
            {
                if (it == _items[i])
                {
                    it.Count--;
                }
            }
        }
        else
        {
            bag.Remove(_items[i]);
        }
    }
}



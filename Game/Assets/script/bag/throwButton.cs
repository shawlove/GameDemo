using UnityEngine;
using System.Collections;

public class throwButton : MonoBehaviour {

    private GameObject playerUI;
    private GameObject trade;
    private GameObject _bagItems;

    private fps_playerParamter paramter;
    void Start()
    {
        playerUI = GameObject.Find("PlayerUI");
        _bagItems = playerUI.transform.Find("Bag/Items/Viewport/Content").gameObject;

        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
    }

    public void Click()
    {
        foreach (item it in _bagItems.GetComponentsInChildren<item>())
        {
            if (it.IsSelect)
            {
                gameItem.deleteBagItem(it.id);
            }
        }


    }
}

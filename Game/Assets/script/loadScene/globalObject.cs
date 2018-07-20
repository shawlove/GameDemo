using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class globalObject : MonoBehaviour {
    public GameObject player;
    public GameObject playerUI;
    public GameObject F;
    public GameObject trade;
    //public GameObject bag;
    //public GameObject skillInterface;
    //public GameObject skillBar;
    //public GameObject statusBar;
    //public GameObject eventSystem;
    // public GameObject load;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(playerUI);
        DontDestroyOnLoad(trade);
        //DontDestroyOnLoad(bag);
       // DontDestroyOnLoad(skillInterface);
        //DontDestroyOnLoad(skillBar);
        //DontDestroyOnLoad(statusBar);
       // DontDestroyOnLoad(eventSystem);
       // DontDestroyOnLoad(load);     
}
    void Start()
    {
        F.SetActive(false);
        trade.transform.Find("Trader").gameObject.SetActive(false);
    }
   /* void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            skillBar.SetActive(false);
            statusBar.SetActive(false);
        }
        else
        {
            skillBar.SetActive(true);
            statusBar.SetActive(true);
        }
    }*/

}

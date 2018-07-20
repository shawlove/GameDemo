using UnityEngine;
using System.Collections;

public class startScenetool : MonoBehaviour {

    public GameObject player;
    public GameObject bag;
    public GameObject skillInterface;
    public GameObject skillBar;
    public GameObject statusBar;
    //public GameObject eventSystem;
    public GameObject gameController;

    void Start()
    {
        player.SetActive(false);
        bag.SetActive(false);
        skillInterface.SetActive(false);
        skillBar.SetActive(false);
        statusBar.SetActive(false);
       // eventSystem.SetActive(false);
        gameController.SetActive(false);
    }
}

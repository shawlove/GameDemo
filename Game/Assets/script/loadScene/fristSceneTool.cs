using UnityEngine;
using System.Collections;

public class fristSceneTool : MonoBehaviour {

    public GameObject player;
    public GameObject bag;
    public GameObject skillInterface;
    public GameObject skillBar;
    public GameObject statusBar;
    //public GameObject eventSystem;
    public GameObject gameController;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        bag = GameObject.FindGameObjectWithTag("bag");
        skillInterface = GameObject.FindGameObjectWithTag("skillInterface");
        skillBar = GameObject.FindGameObjectWithTag("SkillBar");
        statusBar = GameObject.FindGameObjectWithTag("statusBar");
        player.SetActive(true);
        gameController.SetActive(true);
        bag.SetActive(true);
        skillInterface.SetActive(true);
        skillBar.SetActive(true);
        statusBar.SetActive(true);
    }

    void Start()
    {
    }
}

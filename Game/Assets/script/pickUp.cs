using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {
    public int Id;

    private GameObject player;
    private gameItem item;


	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        item= GameObject.FindGameObjectWithTag("GameController").GetComponent<gameItem>();

    }
	
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        print("11111111");
        if (other.gameObject==player)
        {
            Debug.Log("拾取到了");
            //    播放音效
            item.addBagItem(Id);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class playerBattle : MonoBehaviour {
    public int maxHp=100;
    private int currntHp;
    // private fps_playerParamter paramter;
    //private GameObject g;
    private GameObject[] enemy;
    private enemy _enemy;
    private Animator anim;
    private skillDamage skillDamage;
    private RectTransform blood;
    private RectTransform blue;
    public int CurrntHp
    {
        get
        {
            return currntHp;
        }
        set
        {
            currntHp = value;
        }

    }
    private bool battle=false;
    public bool isBattle
    
    {
        get
        {
            return battle;
        }
    }
	
	void Start () {
        // paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        //g = GameObject.FindGameObjectWithTag("teee");
        currntHp = maxHp;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        anim = GetComponent<Animator>();
        skillDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<skillDamage>();
        blood = GameObject.FindGameObjectWithTag("Blood").GetComponent<RectTransform>();
        blue = GameObject.FindGameObjectWithTag("Blue").GetComponent<RectTransform>();
        blood.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 3, 95);
        blue.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,3,95);
    }
	
	
	void Update () {
        blood.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 3, 95*currntHp/maxHp);
        // blue.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 3, 95);
    }


    private void attackJudge(float distance)
    {
        //float dot = 1 / Mathf.Sqrt(2);
        float dot = 0.5f;
        int _damage = 0;
        float _dot = 0;
        Vector3 toOther = new Vector3();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack1")) _damage = 10;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack2")) _damage = 20;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack3")) _damage = 15;
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack4")) _damage = 25;
        //print(distance);

       // print(state);
        foreach (GameObject g in enemy)
        {
            if (g!=null)
            {
                Vector3 v = new Vector3(g.transform.position.x, transform.position.y, g.transform.position.z);
                toOther = v - transform.position;//y轴要一样，enemy 和 player
                _dot = Vector3.Dot(forward, toOther);



                if (toOther.magnitude <= distance && dot * distance <= _dot)
                {
                    g.GetComponent<enemy>().PlayerObj = this.gameObject;
                    g.GetComponent<enemy>().IsAttacked = true;
                    g.GetComponent<enemy>().Hp -= _damage;
                }
            }           
  
            
        }
    }
    /**
     * 把这个函数放在动画的某一帧，执行伤害判定
    **/
    private void damageJudge(float distance)
    {
       
        if (skillDamage.learnedSkill!=null)
        {
            //float dot = 1 / Mathf.Sqrt(2);
            float dot = 0.5f;
            float _dot = 0;// 局部变量
            int _damage = 0;
            int _skillState = 0;
            Vector3 toOther = new Vector3();
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.stun")) _skillState = 1;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.flail")) _skillState = 2;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.healward")) _skillState = 3;
            foreach (KeyValuePair<int, skillDamage._skill> pair in skillDamage.learnedSkill)
            {
                if (pair.Value.skillState == _skillState)
                {
                    _damage = pair.Value.damage;
                    //print(_damage);
                }
            }
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            foreach (GameObject g in enemy)
            {
                if (g!=null)
                {
                    Vector3 v = new Vector3(g.transform.position.x, transform.position.y, g.transform.position.z);
                    toOther = v - transform.position;//y轴要一样，enemy 和 player
                    _dot = Vector3.Dot(forward, toOther);
                    if (toOther.magnitude <= distance && dot * distance <= _dot)
                    {
                        g.GetComponent<enemy>().PlayerObj = this.gameObject;
                        g.GetComponent<enemy>().IsAttacked = true;
                        g.GetComponent<enemy>().Hp -= _damage;
                    }
                }              
                
                
            }

        }
   
          
     
    }

    private void Battle()
    {

    }
    
}

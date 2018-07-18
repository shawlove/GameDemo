using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerAnim : MonoBehaviour {

    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    private fps_playerParamter paramter;
    private  Animator anim;
    private float random;
    private Vector2 currentMove = Vector2.zero;
    private bool currentAttack01 = false;
    private bool currentAttack02 = false;
    private GameObject[] skillBars;
    private int skillState;
    public Dictionary<int, float> cooling = new Dictionary<int, float>();
    public float[] cools=new float[10];


    void Start()
    {
        paramter = this.GetComponent<fps_playerParamter>();
        anim = this.GetComponent<Animator>();
 
    }


    void Update()
    {
        animControll();
        skillBarDown();
        foreach (KeyValuePair<int,float> pair in cooling)
        {
            if (cools[pair.Key]<pair.Value)
            {
                cools[pair.Key] += Time.deltaTime;
            }
            
        }
        
    }
    
    public void skillAnimEvent()
    {
        anim.SetInteger("skill",0);
    }

    private void skillBarDown()
    {
        skillBars = GameObject.FindGameObjectsWithTag("skillBar");
        if (paramter.isSkillbar01&&bar1.transform.childCount!=0)
        {
            skillState = bar1.GetComponentInChildren<skill>().SkillState;
            if (cooling.ContainsKey(bar1.GetComponentInChildren<skill>().Id))
            {
                if (cools[bar1.GetComponentInChildren<skill>().Id]>= bar1.GetComponentInChildren<skill>().CoolTime)
                {
                    anim.SetInteger("skill", skillState);
                    
                    cools[bar1.GetComponentInChildren<skill>().Id] = 0;
                }
            }
            else
            {
                anim.SetInteger("skill", skillState);
                cooling[bar1.GetComponentInChildren<skill>().Id] = bar1.GetComponentInChildren<skill>().CoolTime;
                cools[bar1.GetComponentInChildren<skill>().Id] = 0;
                //skillBars[0].GetComponentInChildren<Image>().color = new Color(194/255,194/255,194/255);
            }
            
        }
        if (paramter.isSkillbar02&&bar2.transform.childCount != 0)
        {
            skillState = bar2.GetComponentInChildren<skill>().SkillState;
            //anim.SetInteger("skill", skillState);
            if (cooling.ContainsKey(bar2.GetComponentInChildren<skill>().Id))
            {
                if (cools[bar2.GetComponentInChildren<skill>().Id] >= bar2.GetComponentInChildren<skill>().CoolTime)
                {
                    anim.SetInteger("skill", skillState);

                    cools[bar2.GetComponentInChildren<skill>().Id] = 0;
                }
            }
            else
            {
                anim.SetInteger("skill", skillState);
                cooling[bar2.GetComponentInChildren<skill>().Id] = bar2.GetComponentInChildren<skill>().CoolTime;
                cools[bar2.GetComponentInChildren<skill>().Id] = 0;
                //skillBars[1].GetComponentInChildren<Image>().color = new Color(194 / 255, 194 / 255, 194 / 255);
            }
        }
        if (paramter.isSkillbar03 && bar3.transform.childCount != 0)
        {
            skillState = bar3.GetComponentInChildren<skill>().SkillState;
            //anim.SetInteger("skill", skillState);
            if (cooling.ContainsKey(bar3.GetComponentInChildren<skill>().Id))
            {
                if (cools[bar3.GetComponentInChildren<skill>().Id] >= bar3.GetComponentInChildren<skill>().CoolTime)
                {
                    anim.SetInteger("skill", skillState);

                    cools[bar3.GetComponentInChildren<skill>().Id] = 0;
                }
            }
            else
            {
                anim.SetInteger("skill", skillState);
                cooling[bar3.GetComponentInChildren<skill>().Id] = bar3.GetComponentInChildren<skill>().CoolTime;
                cools[bar3.GetComponentInChildren<skill>().Id] = 0;
               // skillBars[2].GetComponentInChildren<Image>().color = new Color(194 / 255, 194 / 255, 194 / 255);
            }
        }
        if (paramter.isSkillbar04 && bar4.transform.childCount != 0)
        {
            skillState = bar4.GetComponentInChildren<skill>().SkillState;
            //anim.SetInteger("skill", skillState);
            if (cooling.ContainsKey(bar4.GetComponentInChildren<skill>().Id))
            {
                if (cools[bar4.GetComponentInChildren<skill>().Id] >= bar4.GetComponentInChildren<skill>().CoolTime)
                {
                    anim.SetInteger("skill", skillState);

                    cools[bar4.GetComponentInChildren<skill>().Id] = 0;
                }
            }
            else
            {
                anim.SetInteger("skill", skillState);
                cooling[bar4.GetComponentInChildren<skill>().Id] = bar4.GetComponentInChildren<skill>().CoolTime;
                cools[bar4.GetComponentInChildren<skill>().Id] = 0;
               // skillBars[3].GetComponentInChildren<Image>().color = new Color(194 / 255, 194 / 255, 194 / 255);
            }
        }
        //这里想用触发器做，，这样感觉很蠢。以后来改
    }

    private void animControll()
    {
        
        currentMove.x = paramter.inputMoveVector.x;
        currentMove.y = paramter.inputMoveVector.y;

        currentAttack01 = paramter.inputAttack01;
        currentAttack02 = paramter.inputAttack02;
        anim.SetFloat("turn",currentMove.x);
        anim.SetFloat("forward", currentMove.y);
       
        if (currentAttack01)
        {

            if (Random.Range(0f, 10f) < 3f)
            {
                anim.SetInteger("state", 3);
            }
            else
            {
                anim.SetInteger("state", 1);
            }

        }
        else
        {
            anim.SetInteger("state", 0);
        }
       
        if (currentAttack02)
        {
            
            if (Random.Range(0f, 10f) < 3f)
            {
                anim.SetInteger("state", 4);
            }
            else
            {
                anim.SetInteger("state", 2);
            }
            
           
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        if (paramter.isBattle)
        {
            anim.SetFloat("isBattle",0);
        }else
        {
            if (currentMove == Vector2.zero)
            {
                
        
                anim.SetFloat("isBattle", 1);
                
            }

            anim.SetFloat("isBattle", 0);

        }


    }
   
    


}

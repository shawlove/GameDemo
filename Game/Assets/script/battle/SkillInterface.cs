using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillInterface : MonoBehaviour {
    public GameObject gird;
    public GameObject obj;
    private GameObject prefab;
    private GameObject prefabGird;
    private  CanvasRenderer[] renderer;
    private  CanvasRenderer[] r1;
    private  CanvasRenderer[] r2;
    private GameObject[] r3;
    private GameObject[] r4;
    private fps_playerParamter paramter;
    private skillDamage skill;
    private skill _skill;
    private skill[] _lskills;
    private skill[] _uskills;
    private GameObject lcontent;
    private GameObject ucontent;
    private bool isContainsU;
    private bool isContainsL;
    private bool b;

    void Start()
    {
        renderer= this.GetComponentsInChildren<CanvasRenderer>();
        paramter = GameObject.FindGameObjectWithTag("Player").GetComponent<fps_playerParamter>();
        skill = GameObject.FindGameObjectWithTag("GameController").GetComponent<skillDamage>();
        lcontent = GameObject.FindGameObjectWithTag("learnedSkills");
        ucontent = GameObject.FindGameObjectWithTag("unlearnedSkills");
        r1 = lcontent.GetComponentsInChildren<CanvasRenderer>();
        r2=ucontent.GetComponentsInChildren<CanvasRenderer>();
    }
    void Update()
    {
        skillInterface();
    }

     private void  skillInterface()
    {
        r3 = GameObject.FindGameObjectsWithTag("skill");
        r4 = GameObject.FindGameObjectsWithTag("Grid");
        if (paramter.isSkillInterface)
        {
            
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(1);
            }
            foreach (CanvasRenderer r in r1)
            {
                r.SetAlpha(1);
            }
            foreach (CanvasRenderer r in r2)
            {
                r.SetAlpha(1);
            }
            foreach (GameObject g in r3)
            {
                g.GetComponent<CanvasRenderer>().SetAlpha(1);
            }
            foreach (GameObject g in r4)
            {
                g.GetComponent<CanvasRenderer>().SetAlpha(1);
            }
        }
        else
        {
            foreach (CanvasRenderer r in renderer)
            {
                r.SetAlpha(0);
            }
            foreach (CanvasRenderer r in r1)
            {
                r.SetAlpha(0);
            }
            foreach (CanvasRenderer r in r2)
            {
                r.SetAlpha(0); 
            }
            foreach (GameObject g in r3)
            {
                g.GetComponent<CanvasRenderer>().SetAlpha(0);
            }
            foreach (GameObject g in r4)
            {
                g.GetComponent<CanvasRenderer>().SetAlpha(0);
            }
        }

        _lskills = lcontent.GetComponentsInChildren<skill>();
        _uskills = ucontent.GetComponentsInChildren<skill>();


        foreach (KeyValuePair<int,skillDamage._skill> pair in skill.skills)
        {
            


             isContainsU=false;
            for (int i=0;i<_uskills.Length;i++)
            {
                if(_uskills[i].Id == pair.Value.id)
                {
                    isContainsU = true;
                }
            }
            if (!isContainsU)
            {
                prefabGird = Instantiate(gird);
                prefab = Instantiate(obj);
                _skill = prefab.GetComponent<skill>();
                _skill.Id = pair.Value.id;
                _skill.Sprite = pair.Value.sprite;
                _skill.Damage = pair.Value.damage;
                _skill.Name = pair.Value._name;
                _skill.Description = pair.Value.description;
                _skill.SkillState = pair.Value.skillState;
                _skill.CoolTime = pair.Value.coolTime;
                prefab.GetComponent<Drag>().enabled = false;
                prefabGird.transform.SetParent(ucontent.transform,false);
                prefab.transform.SetParent(prefabGird.transform, false);
                prefab.transform.position = prefabGird.transform.position;
            }
          /*  foreach (KeyValuePair<int, skillDamage._skill> _pair in skill.learnedSkill)
            {
               
                for (int i = 0; i < _uskills.Length; i++)
                {
                    if(_uskills[i].Id == _pair.Key)
                    {
                        b = true;
                        //_uskills[i].Description += "/n 已学习该技能";
                    }else
                    {
                        b = false;
                        //_uskills[i].Description.Replace("/n 已学习该技能","");
                    }
                    if (b)
                    {
                        _uskills[i].Description += "/n 已学习该技能";
                    }
                    else
                    {
                        _uskills[i].Description.Replace("/n 已学习该技能", "");
                    }
                }
            }*/

        }
        for (int i = 0; i < _lskills.Length; i++)
        {
            if (!skill.learnedSkill.ContainsKey(_lskills[i].Id))
            {
                // Destroy(_lskills[i].gameObject);
                Destroy(_lskills[i].transform.parent.gameObject);
            }
        }
        foreach (KeyValuePair<int, skillDamage._skill> pair in skill.learnedSkill)
        {
            if (pair.Key!=0) {
                isContainsL = false;
                for (int i = 0; i < _lskills.Length; i++)
                {
                    if (_lskills[i].Id == pair.Value.id)
                    {
                        isContainsL = true;
                    }
                }
                if (!isContainsL)
                {
                    prefabGird = Instantiate(gird);
                    prefab = Instantiate(obj);
                    _skill = prefab.GetComponent<skill>();
                    _skill.Id = pair.Value.id;
                    _skill.Sprite = pair.Value.sprite;
                    _skill.Damage = pair.Value.damage;
                    _skill.Name = pair.Value._name;
                    _skill.Description = pair.Value.description;
                    _skill.SkillState = pair.Value.skillState;
                    _skill.CoolTime = pair.Value.coolTime;
                    prefabGird.transform.SetParent(lcontent.transform, false);
                    prefab.transform.SetParent(prefabGird.transform, false);
                    prefab.transform.position = prefabGird.transform.position;
                }
                //if (_lskills.Length >= skill.learnedSkill.Count)
                //{

                  
                //}
                //if (skill.learnedSkill==null)
                //{
               //     Destroy(_lskills[0].gameObject);
               // }

            }
        }
    }





    
}

using UnityEngine;
using System.Collections;
//遗忘
public class buttonClik : MonoBehaviour {

    private Animator anim;
    private GameObject lcontent;
    private GameObject ucontent;
    private skill[] _lskills;
    private skill[] _uskills;
    private skillDamage skills;

    void Start()
    {
        anim = GetComponent<Animator>();
        lcontent = GameObject.FindGameObjectWithTag("learnedSkills");
        ucontent = GameObject.FindGameObjectWithTag("unlearnedSkills");
        skills = GameObject.FindGameObjectWithTag("GameController").GetComponent<skillDamage>();
    }


    public void Click()
    {
        _lskills = lcontent.GetComponentsInChildren<skill>();
        _uskills = ucontent.GetComponentsInChildren<skill>();
        foreach (skill s in _lskills)
        {
            if (s.Count==1)
            {
                skills.forgetSkill(s.Id);
            }
        }
        foreach (skill s in _uskills)
        {
            if (s.Count==1)
            {
                print("不能忘记未学习技能");
            }
        }
        print("click");
        anim.SetTrigger("Highlighted");

    }
}

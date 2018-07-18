using UnityEngine;
using System.Collections;
//学习
public class buttonClick0 : MonoBehaviour {
    private Animator anim;
    private GameObject lcontent;
    private GameObject ucontent;
    private skill[] _lskills;
    private skill[] _uskills;
    private skillDamage skills;
    void Start () {
        anim = GetComponent<Animator>();
        lcontent = GameObject.FindGameObjectWithTag("learnedSkills");
        ucontent = GameObject.FindGameObjectWithTag("unlearnedSkills");
        skills = GameObject.FindGameObjectWithTag("GameController").GetComponent<skillDamage>();
    }

    public void Click()
    {
        print("cccc");
        _lskills = lcontent.GetComponentsInChildren<skill>();
        _uskills = ucontent.GetComponentsInChildren<skill>();
        foreach (skill s in _lskills)
        {
            if (s.Count == 1)
            {
                print("不能学习已学习技能");
            }
        }
        foreach (skill s in _uskills)
        {
            if (s.Count == 1)
            {
                skills.learnSkill(s.Id);

            }
        }

        anim.SetTrigger("Highlighted");

    }
}

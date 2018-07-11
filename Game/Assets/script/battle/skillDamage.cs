using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class skillDamage : MonoBehaviour {

    public class _skill
    {
        public string _name;
        public int damage;
        public int id;
        public string description;
        public Sprite sprite;
        public int skillState;
        public float coolTime;
    }
    public Dictionary<int, _skill> skills = new Dictionary<int, _skill>();

    public Dictionary<int,_skill> learnedSkill = new Dictionary<int,_skill>();

    void Start()
    {
        //learnedSkill.Add(0, new _skill { _name = "", damage = 0, id = 0, description = "", sprite = null });
        Sprite[] sprites = Resources.LoadAll<Sprite>("picture/Icons") ;
        addSkill(1, "stun", 10, "一个动作", sprites[0],1,2);
        addSkill(2,"falil",20,"一个动作",sprites[1],2,3);
        addSkill(3,"healwaed",25,"。。。。",sprites[2],3,4);
        addSkill(4, "技能4", 25, "技能4，待定", sprites[3],4,5);
    }



    private void addSkill(int id, string n, int dam,string des,Sprite s,int skill,float cool)
    {
        if (skills.ContainsKey(id))
            skills[id] = new _skill() { _name = n, damage = dam, id = id ,description=des,sprite=s,skillState=skill,coolTime=cool};
        else
            skills.Add(id, new _skill() { _name = n, damage = dam, id = id ,description= des, sprite = s , skillState = skill,coolTime=cool });
    }

    public void learnSkill(int i)
    {
        if (learnedSkill.ContainsValue(skills[i]))
        {
            print("此技能已经被学习过了");
        }
        else
        {
            learnedSkill[i] = skills[i];
        }
    }

    public void forgetSkill(int i)
    {
        if (learnedSkill.ContainsValue(skills[i]))
        {
            learnedSkill.Remove(i);
            print("ppapapapap");
        }else
        {
            print("还未学习的技能不能忘记");
        }
    }


}

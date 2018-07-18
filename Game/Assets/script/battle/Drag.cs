using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Drag : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject parentObj;

    private Transform originalParent;
    private Image image;
    private GameObject goal;
    private GameObject clone;
    private skill _skill;
    private GameObject[] objs;
    private GameObject[] barskills;

    void Start()
    {
        image = GetComponent<Image>();
        parentObj = GameObject.FindGameObjectWithTag("Drag");
        _skill = GetComponent<skill>();
        objs = GameObject.FindGameObjectsWithTag("skill");

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        barskills = GameObject.FindGameObjectsWithTag("BarSkill");
        if (image.sprite == null)
        {
            return;
        }
        originalParent = transform.parent;
        //clone=Instantiate(this,transform.parent,true);
        clone =Instantiate(this.gameObject);
        skill s = clone.GetComponent<skill>();
        s.Id = _skill.Id;
        s.Description = _skill.Description;
        s.Sprite = _skill.Sprite;
        s.Count = _skill.Count;
        s.Damage = _skill.Damage;
        s.name = _skill.name;
        s.SkillState = _skill.SkillState;
        s.CoolTime = _skill.CoolTime;
        clone.transform.SetParent(originalParent,false);
        clone.transform.position = originalParent.position;
        clone.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        transform.SetParent(parentObj.transform, false);
        transform.position = parentObj.transform.position;
        SetDraggedPosition(eventData);
        image.raycastTarget = false;
                foreach (GameObject g in objs)
        {
            if (g != null)
            {
                g.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }



    public void OnDrag(PointerEventData eventData)
    {
        if (image.sprite == null)
        {
            return;
        }
        SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (image.sprite == null)
        {
            return;
        }
        goal = eventData.pointerCurrentRaycast.gameObject;
        print(goal.name);
        if (goal!=null)
        {
            if (goal.name.Length>=5)
            {
                if (goal.name.Substring(0, 5).Equals("BGrid"))
                {
                    print("检测到BGrid");
                    transform.SetParent(goal.transform, false);
                    transform.position = goal.transform.position;
                    transform.gameObject.tag = "BarSkill";
                    foreach (GameObject g in barskills)
                    {
                        if (g.GetComponent<skill>().Id==GetComponent<skill>().Id)
                        {
                            Destroy(g.gameObject);
                        }
                    }

                }
                else if (goal.name.Substring(0, 5).Equals("Skill"))
                {
                    print("检测到Skill");
                    Destroy(originalParent.GetChild(0).gameObject);
                    Transform t = goal.transform.parent;
                    goal.transform.SetParent(originalParent, false);
                    goal.transform.position = originalParent.position;
                    transform.SetParent(t, false);
                    transform.position = t.transform.position;
                    if (t.gameObject.name.Substring(0,5).Equals("BGrid"))
                    {
                        
                        transform.gameObject.tag = "BarSkill";
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            print("检测到null");
            Destroy(this.gameObject);
        }

        image.raycastTarget = true;

    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }


}

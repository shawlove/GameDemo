using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
public class fps_playerParamter : MonoBehaviour {
    [HideInInspector]
    public Vector2 inputSmoothLook;//鼠标输入
    [HideInInspector]
    public Vector2 inputMoveVector;
    [HideInInspector]
    public bool inputJump;
    [HideInInspector]
    public bool inputSprint;
    [HideInInspector]
    public bool inputAttack01;
    [HideInInspector]
    public bool inputAttack02;
    [HideInInspector]
    public bool isBattle;
    [HideInInspector]
    public bool isBagOpen;
    [HideInInspector]
    public int currentHP;
    [HideInInspector]
    public bool isSkillInterface;
    [HideInInspector]
    public bool isSkillbar01;
    [HideInInspector]
    public bool isSkillbar02;
    [HideInInspector]
    public bool isSkillbar03;
    [HideInInspector]
    public bool isSkillbar04;
    [HideInInspector]
    public bool isSkillbar05;







}

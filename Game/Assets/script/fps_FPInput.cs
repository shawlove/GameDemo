using UnityEngine;
using System.Collections;
using System;

public class fps_FPInput : MonoBehaviour {

    public bool LockCursor
    {
        get { return Cursor.lockState == CursorLockMode.Locked ? true : false; }
        set
        {
            Cursor.visible = value?false:true;
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    private fps_playerParamter paramter;
    private fps_input input;
    private Animator anim;
    private playerBattle battle;

    void Start()
    {
        LockCursor = true;
        paramter = this.GetComponent<fps_playerParamter>();
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<fps_input>();
        anim = this.GetComponent<Animator>();
        battle = this.GetComponent<playerBattle>();
    }
    void Update()
    {
        InitialInput();
    }

    private void InitialInput()
    {
        
        paramter.inputMoveVector = new Vector2(input.GetAxis("Horizontal"), input.GetAxis("Vertical"));      
        paramter.inputSmoothLook = new Vector2(input.GetAxisRaw("Mouse X"), input.GetAxisRaw("Mouse Y"));//相机控制
        paramter.inputSprint = input.GetButton("Sprint");
        paramter.inputJump = input.GetButton("Jump");
        paramter.inputAttack01 = input.GetButton("Attack01");
        paramter.inputAttack02 = input.GetButton("Attack02");
        paramter.isBattle = battle.isBattle;
        paramter.currentHP = battle.CurrntHp;
        paramter.isSkillInterface = input.GetButton("SkillInterface");
        paramter.isSkillbar01 = input.GetButton("SkillBar01");
        paramter.isSkillbar02 = input.GetButton("SkillBar02");
        paramter.isSkillbar03 = input.GetButton("SkillBar03");
        paramter.isSkillbar04 = input.GetButton("SkillBar04");
        paramter.isSkillbar05 = input.GetButton("SkillBar05");
        paramter.isBagOpen = input.GetButton("BagOpen");
        if (paramter.isBagOpen||paramter.isSkillInterface)
        {
            LockCursor = false;
            paramter.inputSmoothLook = Vector2.zero;
        }else
        {
            LockCursor = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack2")||anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack1")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack3")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack4")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.stun")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.flail")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.healward"))
        {
            paramter.inputMoveVector = Vector2.zero;

        }
    }
}

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

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
    private int cInterface = 0;
    private int cBag = 0;

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
        if (SceneManager.GetActiveScene().name=="StartScene")
        {
            LockCursor = false;
        }
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
        //paramter.F = input.GetButtonDown("F");
        /*if (input.GetButtonDown("F"))
        {
            paramter.F = true;
            if (cBag == 1)
            {
                cBag--;
                paramter.isBagOpen = false;
            }
            if (cInterface == 1)
            {
                cInterface--;
                paramter.isSkillInterface = false;
            }
        }
        else
        {
            paramter.F = false;
        }*/
        paramter.isBattle = battle.isBattle;
        paramter.currentHP = battle.CurrntHp;
        if (input.GetButtonDown("SkillInterface") && cInterface == 0)
        {
            if (cBag == 1)
            {
                cBag--;
                paramter.isBagOpen = false;
            }
            cInterface++;
            paramter.isSkillInterface = true;
        }
        else if (input.GetButtonDown("SkillInterface") && cInterface == 1)
        {
            cInterface--;
            paramter.isSkillInterface = false;
        }
        if (input.GetButtonDown("BagOpen") && cBag == 0)
        {
            if (cInterface == 1)
            {
                cInterface--;
                paramter.isSkillInterface = false;
            }
            cBag++;
            paramter.isBagOpen = true;
        }
        else if (input.GetButtonDown("BagOpen") && cBag == 1)
        {
            cBag--;
            paramter.isBagOpen = false;
        }
        //paramter.isBagOpen = input.GetButton("BagOpen");
        //paramter.isSkillInterface = input.GetButton("SkillInterface");
        paramter.isSkillbar01 = input.GetButton("SkillBar01");
        paramter.isSkillbar02 = input.GetButton("SkillBar02");
        paramter.isSkillbar03 = input.GetButton("SkillBar03");
        paramter.isSkillbar04 = input.GetButton("SkillBar04");
        paramter.isSkillbar05 = input.GetButton("SkillBar05");
        if (paramter.isBagOpen||paramter.isSkillInterface||paramter.isTrade)
        {
            LockCursor = false;
            paramter.inputSmoothLook = Vector2.zero;
        }else if(SceneManager.GetActiveScene().name != "StartScene")
        {
            LockCursor = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack2")||anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack1")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack3")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack4")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.stun")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.flail")|| anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.healward"))
        {
            paramter.inputMoveVector = Vector2.zero;

        }
    }


}

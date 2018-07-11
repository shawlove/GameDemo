using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fps_input : MonoBehaviour {

    public class fps_InputAxis
    {
        public KeyCode positive;
        public KeyCode negative;
    }

    public Dictionary<string, KeyCode> buttons = new Dictionary<string, KeyCode>();
    public Dictionary<string, fps_InputAxis> axis = new Dictionary<string, fps_InputAxis>();
    public List<string> unityAxis = new List<string>();

    void Start()
    {
        SetupDefaluts();
    }

    private void SetupDefaluts(string type = "")
    {
        if(type==""||type=="buttons")
        {
            if (buttons.Count == 0)
            {
                AddButton("Attack01", KeyCode.Mouse0);
                AddButton("Attack02", KeyCode.Mouse1);
                AddButton("Jump", KeyCode.Space);
                AddButton("Sprint", KeyCode.LeftShift);
                AddButton("BagOpen", KeyCode.Tab);
                AddButton("SkillInterface",KeyCode.K);
                AddButton("SkillBar01",KeyCode.Alpha1);
                AddButton("SkillBar02", KeyCode.Alpha2);
                AddButton("SkillBar03", KeyCode.Alpha3);
                AddButton("SkillBar04", KeyCode.Alpha4);
                AddButton("SkillBar05", KeyCode.Alpha5);
            }
        }
        if (type == "" || type == "axis")
        {
            if (axis.Count == 0)
            {
                AddAxis("Horizontal", KeyCode.A, KeyCode.D);
                AddAxis("Vertical", KeyCode.W, KeyCode.S);

            }
        }
        if (type == "" || type == "unityAxis")
        {
            if (unityAxis.Count == 0)
            {
                AddUnityAxis("Mouse X");
                AddUnityAxis("Mouse Y");
                AddUnityAxis("Horizontal");
                AddUnityAxis("Vertical");
            }
        }
    }


    private void  AddButton(string n,KeyCode k)
    {
        if (buttons.ContainsKey(n))
            buttons[n] = k;
        else
            buttons.Add(n, k);
    }

    private void AddAxis(string n,KeyCode pk,KeyCode nk)
    {
        if (axis.ContainsKey(n))
            axis[n] = new fps_InputAxis() { positive = pk, negative = nk };
        else
            axis.Add(n, new fps_InputAxis() { positive = pk, negative = nk });

    }

    private void AddUnityAxis(string n)
    {
        if (!unityAxis.Contains(n))
            unityAxis.Add(n);
    }

    public bool GetButton(string button)
    {
        if (buttons.ContainsKey(button))
        {
            return Input.GetKey(buttons[button]);
        }
        return false;
    }

    public bool GetButtonDown(string button)
    {
        if (buttons.ContainsKey(button))
        {
            return Input.GetKeyDown(buttons[button]);
        }
        return false;
    }

    public float GetAxis(string axis)
    {
        if (this.unityAxis.Contains(axis))
        {
            return Input.GetAxis(axis);
        }
        else
            return 0;
    }

    public float GetAxisRaw(string axis)
    {
        if (this.axis.ContainsKey(axis))
        {
            float val = 0;
            if (Input.GetKey(this.axis[axis].positive))
                return 1;
            if (Input.GetKey(this.axis[axis].negative))
                return -1;
            return val;
        }
        else if (unityAxis.Contains(axis))
        {
            return Input.GetAxisRaw(axis);
        }
        else
            return 0;

    }


}

using AOT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CPPCallCs_MonoPInvokeCallback : MonoBehaviour
{
    public Text txt;
    public Button btn;
    public static string s_msg = "";

    void Start()
    {
        InitCSharpDelegate(LogMessageFromCpp);

        btn.onClick.AddListener(() => 
        {
            //C#调用C
            HelloCppToCs("I am Unity");
        });
    }

    void Update()
    {
        if(!string.IsNullOrEmpty(s_msg))
            txt.text = s_msg;
    }

    [MonoPInvokeCallback(typeof(LogDelegate))]
    public static void LogMessageFromCpp(IntPtr message, int iSize)
    {
        s_msg = "C#被C++调用\n";
        s_msg += Marshal.PtrToStringAnsi(message, iSize);
        Debug.Log(s_msg);
    }

    public delegate void LogDelegate(IntPtr message, int iSize);

    [DllImport("linxinfa_so")]
    public static extern void InitCSharpDelegate(LogDelegate log);

    [DllImport("linxinfa_so")]
    public static extern void HelloCppToCs(string msg);
}

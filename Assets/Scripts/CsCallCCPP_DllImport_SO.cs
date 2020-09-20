using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CsCallCCPP_DllImport_SO : MonoBehaviour
{
    public Text txt;
    public Button btn1;
    public Button btn2;

    void Start()
    {
        btn1.onClick.AddListener(() => 
        {
            //C#调用C
            txt.text = "C#调用C接口: AddInt(2, 6) = " + AddInt(2, 6);
        });

        btn2.onClick.AddListener(() => 
        {
            //C#调用C++
            txt.text = "C#调用C++接口: AddFloat(2.7, 4.2) = " + AddFloat(2.7f, 4.2f);
        });


    }

    //C接口
    [DllImport("linxinfa_so")]
    public static extern int AddInt(int a, int b);

    //C++接口
    [DllImport("linxinfa_so")]
    public static extern float AddFloat(float a, float b);
}

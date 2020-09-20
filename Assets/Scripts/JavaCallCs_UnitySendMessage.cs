using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavaCallCs_UnitySendMessage : MonoBehaviour
{
    public Text txt;
    public Button btn;


    void Start()
    {
        btn.onClick.AddListener(() => 
        {
            var jc = new AndroidJavaClass("com.linxinfa.game.MyActivity");
            jc.CallStatic("JavaCallCSharp", "I am Unity");
        });
    }

    public void OnJavaMsg(string msg)
    {
        txt.text = msg;
    }
}

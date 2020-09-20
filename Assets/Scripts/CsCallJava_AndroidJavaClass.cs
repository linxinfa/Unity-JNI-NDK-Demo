using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsCallJava_AndroidJavaClass : MonoBehaviour
{
    public Text txt;
    public Button btn1;
    public Button btn2;

    void Start()
    {
        btn1.onClick.AddListener(() => 
        {
            //通过对象调用非静态接口
            var jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            txt.text = jo.Call<string>("HelloMethod", "I am Unity") + "\n";
        });

        btn2.onClick.AddListener(() => 
        {
            //通过类调用静态接口
            var jc = new AndroidJavaClass("com.linxinfa.game.MyActivity");
            txt.text = jc.CallStatic<string>("HelloStaticMethod", 10, 15);
        });
    }
}

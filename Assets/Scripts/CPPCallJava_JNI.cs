using UnityEngine;
using UnityEngine.UI;

public class CPPCallJava_JNI : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            var jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            //C#调用java接口，然后java中会通过JNI去调用C++接口，再然后C++接口中会通过JNI调用java接口
            jo.Call("CsCallJavaThenJavaCallCppThenCppCallJava");
        });
    }
}

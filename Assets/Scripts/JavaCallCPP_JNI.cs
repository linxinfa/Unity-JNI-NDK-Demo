using UnityEngine;
using UnityEngine.UI;

public class JavaCallCPP_JNI : MonoBehaviour
{
    public Button btn;

    void Start()
    {
        btn.onClick.AddListener(() =>
        {
            var jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
            //调用java接口，java中会通过JNI去调用C++接口
            jo.Call("JavaCallCpp");
        });
    }
}

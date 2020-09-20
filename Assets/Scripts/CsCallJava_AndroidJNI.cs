using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CsCallJava_AndroidJNI : MonoBehaviour
{
    public Text txt;
    public Button btn1;
    public Button btn2;

    void Start()
    {
        btn1.onClick.AddListener(() =>
        {
            //通过对象调用非静态接口-----------------------------------------------------------------

            //获得类
            IntPtr clz = AndroidJNI.FindClass("com/unity3d/player/UnityPlayer");
            IntPtr fid = AndroidJNI.GetStaticFieldID(clz, "currentActivity", "Landroid/app/Activity;");
            //获得静态属性
            IntPtr obj = AndroidJNI.GetStaticObjectField(clz, fid);
            //获得类
            IntPtr clz_OurAppActitvityClass = AndroidJNI.FindClass("com/linxinfa/game/MyActivity");
            //获得方法
            IntPtr methodId = AndroidJNI.GetMethodID(clz_OurAppActitvityClass, "HelloMethod", "(Ljava/lang/String;)Ljava/lang/String;");

            //参数
            jvalue v = new jvalue();
            v.l = AndroidJNI.NewStringUTF("I am Unity");
            
            var result = AndroidJNI.CallStringMethod(obj, methodId, new jvalue[] { v });
            txt.text =result;

            AndroidJNI.DeleteLocalRef(clz);
            AndroidJNI.DeleteLocalRef(fid);
            AndroidJNI.DeleteLocalRef(obj);
            AndroidJNI.DeleteLocalRef(clz_OurAppActitvityClass);
            AndroidJNI.DeleteLocalRef(methodId);

        });

        btn2.onClick.AddListener(() =>
        {
            //通过类调用静态接口----------------------------------------------------------------------------
            //获得类
            IntPtr clz = AndroidJNI.FindClass("com/linxinfa/game/MyActivity");
            //调用静态方法
            IntPtr methodId = AndroidJNI.GetStaticMethodID(clz, "HelloStaticMethod", "(II)Ljava/lang/String;");
            //参数
            jvalue v1 = new jvalue();
            v1.i = 10;
            jvalue v2 = new jvalue();
            v2.i = 15;
            var result = AndroidJNI.CallStaticStringMethod(clz, methodId, new jvalue[] { v1, v2 });

            txt.text = result;

            AndroidJNI.DeleteLocalRef(clz);
            AndroidJNI.DeleteLocalRef(methodId);
        });
    }
}

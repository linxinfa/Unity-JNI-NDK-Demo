package com.linxinfa.game;
 
import android.os.Bundle;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;
 
import android.widget.Toast;
 
public class MyActivity extends UnityPlayerActivity
{
	
	private String m_hi;
	
    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
		m_hi = "hi, 我是java";
    }   
 
	//非静态接口
	public String HelloMethod(String msg)
	{
		return m_hi + ", 我是非静态接口，你传给我的参数是: " + msg;
	}
 
	//静态接口
	public static String HelloStaticMethod(int a, int b)
	{
		return "你好，我是java静态接口，a + b = " + (a+b);
	}
 
	
	public static void JavaCallCSharp(String msg)
	{
		String returnMsg = "hello,我是java, 我通过UnityPlayer.UnitySendMessage返回消息给你: " + msg;
		UnityPlayer.UnitySendMessage("JavaMsgRecver", "OnJavaMsg", returnMsg);
	}
	
	public void JavaCallCpp()
	{
		//调用c++接口
		int result = TestJNIAddInt(4, 5);
		//展示运算结果
		Toast.makeText(this, "java调用c++, 4 + 5 = " + result, Toast.LENGTH_LONG).show();
	}
	
	public void CsCallJavaThenJavaCallCppThenCppCallJava()
	{
		JNICppCallJava();
	}
	
	public void CppCallJavaMethod(String msg)
	{
		Toast.makeText(this, "c++调用java：" + msg, Toast.LENGTH_LONG).show();
	}
	
	//声明.cpp中的TestJNIAddInt方法
    public native int TestJNIAddInt(int a, int b);  
	
	//声明.cpp中的TestJNIAddInt方法
    public native void JNICppCallJava();  
	
	static
	{
    	//加载.so文件
        System.loadLibrary("linxinfa_so");
    }  
}
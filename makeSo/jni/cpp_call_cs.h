#pragma once
#include<string.h>
#include<iostream>
 
extern "C"
{
    class Debug
    {
		public:
			//声明函数指针
			static void (*Log)(char* message,int iSize);
    };

    // 注册C#的委托
    void InitCSharpDelegate(void (*Log)(char* message, int iSize));
 
 	// 给C#调用的C++接口，里面再通过函数指针调用C#的委托
    void HelloCppToCs(char* message);
}
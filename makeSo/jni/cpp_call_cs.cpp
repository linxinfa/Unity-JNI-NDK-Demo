#include "cpp_call_cs.h"

// 定义函数指针，用来接受C#的委托
void(*Debug::Log)(char* message, int iSize);
 
void HelloCppToCs(char* message)
{
	char temp[512]="你好，我是c++, 我收到了你传过来的参数: ";
	//字符串拼接
	strcat(temp, message);
	// 调用C#的委托
    Debug::Log(temp, strlen(temp));
}
 
// 注册C#的委托
void InitCSharpDelegate(void(*Log)(char* message, int iSize))
{
    Debug::Log = Log;
}
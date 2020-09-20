#include <jni.h>

//声明一个类
class  MyMathClass
{
	public:
    static int AddInt(int a, int b)
    {
        return a + b;
    }
 
};


extern "C"
{
	jint
	Java_com_linxinfa_game_MyActivity_TestJNIAddInt(JNIEnv* env, jobject thiz, jint a, jint b)
	{
		return MyMathClass::AddInt(a,b);
	}
}
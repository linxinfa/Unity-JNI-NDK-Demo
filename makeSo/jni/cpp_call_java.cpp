#include <jni.h>

extern "C"
{
	void
	Java_com_linxinfa_game_MyActivity_JNICppCallJava(JNIEnv* env, jobject thiz)
	{
		jclass clz = env->FindClass("com/unity3d/player/UnityPlayer");
		jfieldID fid = env->GetStaticFieldID(clz, "currentActivity", "Landroid/app/Activity;");
		jobject obj = env->GetStaticObjectField(clz, fid);
		jclass clzMyActivity = env->FindClass("com/linxinfa/game/MyActivity");
		jmethodID methodId = env->GetMethodID(clzMyActivity, "CppCallJavaMethod","(Ljava/lang/String;)V");
		jstring msg = env->NewStringUTF("I am c++");
		env->CallVoidMethod(obj, methodId, msg);
	}
}
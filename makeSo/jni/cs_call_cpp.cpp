//声明一个类
class  MyClass
{
	public:
    static float AddFloat(float a, float b)
    {
        return a + b;
    }
 
};


extern "C"
{
	float AddFloat(float a,float b)
	{
		return MyClass::AddFloat(a,b);
	}
}
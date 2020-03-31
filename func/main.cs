using static quad;
using System; 
using static System.Console; 
using static System.Math; 
class main { 
	public static void Main(){
		// First integral in assignment a
		Func<double, double> f = (x) => Log(x) / Sqrt(x);
		double a = 0;
		double b = 1;
		double result = o8av(f, a, b);
		WriteLine("----- log(x)/sqrt(x) -----");
		WriteLine($"a = {a}, b = {b}");
		WriteLine("Expected:	-4");
		WriteLine($"Actual:		{result}");

		// Second integral in assignment a
		f  = (x)  => Exp(-Pow(x, 2));
		a = double.NegativeInfinity;
		b = double.PositiveInfinity;
		result = o8av(f, a, b);
		WriteLine("----- Exp(-Pow(x, 2)) -----");
		WriteLine($"a = {a}, b = {b}");
		WriteLine($"Expected:	{Sqrt(PI)}");
		WriteLine($"Actual:		{result}");
			
		// Third integral in assignment a 
		Func<double, double, double> g = (x, y) => Pow(Log(1/x), y);
		double p = 1;
		f = (x) => g(x, p);
		a = 0;
		b = 1;
		WriteLine("----- log(1/x)^p -----");
		WriteLine($"a = {a}, b = {b}");
		for(int i = 0; i < 5; i++){
			result = o8av(f, a, b);
			WriteLine($"p = {p} ");
			WriteLine($"Expected:	{gamma(p + 1)}");
			WriteLine($"Actual:		{result}");
			p++;
		}
	
		// sin(x)/x from 0 to inf assignment b
		f  = (x)  => Sin(x) / x;
		a = 0;
		b = double.PositiveInfinity;
		result = o8av(f, a, b);
		WriteLine("----- sin(x)/x -----");
		WriteLine($"a = {a}, b = {b}");
		WriteLine($"Expected:	{PI/2}");
		WriteLine($"Actual:		{result}");


		// x^2 / (e^x - 1) from 0 to inf assignment b
		f  = (x)  => Pow(x, 2) / (Exp(x) - 1);
		a = 0;
		b = double.PositiveInfinity;
		result = o8av(f, a, b);
		WriteLine("----- x^2 / (e^x - 1) -----");
		WriteLine($"a = {a}, b = {b}");
		WriteLine($"Expected:	{2.40}");
		WriteLine($"Actual:		{result}");
	

		// x^2 * e^(-a*x^2) from 0 to inf assignment b
		g = (x, y)  => Pow(x, 2) * Exp(-y*Pow(x, 2));
		p = 1;
		f = (x) => g(x, p);
		a = 0;
		b = double.PositiveInfinity;
		result = o8av(f, a, b);
		WriteLine("----- x^2 * e^(-p * x^2) -----");
		WriteLine($"a = {a}, b = {b}");
		for(int i = 0; i < 5; i++){
			result = o8av(f, a, b);
			WriteLine($"p = {p} ");
			WriteLine($"Expected:	{0.25 * (Sqrt(PI / (Pow(p, 3))))}");
			WriteLine($"Actual:		{result}");
			p++;
		}
	}
	
	// D. V. Fedrov's gamma function
	public static double gamma(double x){
		/// single precision gamma function (Gergo Nemes, from Wikipedia)
		if(x<0)return PI/Sin(PI*x)/gamma(1-x);
		if(x<9)return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}
	
}

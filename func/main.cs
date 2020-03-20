using System;
using static System.Console;
//using static System.Double;
using static System.Math;
using static quad;

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
		Func<double, double> g = (x)  => Exp(-Pow(x, 2));
		a = double.NegativeInfinity;
		b = double.PositiveInfinity;
		result = o8av(g, a, b);
		WriteLine("----- Exp(-Pow(x, 2)) -----");
		WriteLine($"a = {a}, b = {b}");
		WriteLine($"Expected:	{Sqrt(PI)}");
		WriteLine($"Actual:		{result}");
		
		// Third integral in assignment a 
		Func<double, double, double> h = (x, y) => Pow(Log(1/x), y);
		double p = 4;
		f = (x) => h(x, p);
		a = 0;
		b = 1;
		result = o8av(f, a, b);

	}
	
}

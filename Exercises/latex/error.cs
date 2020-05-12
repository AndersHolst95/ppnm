using static quad;
using System;
using static System.Console;
using static System.Math;

class main{
	public static void Main() {
		Func<double, double> f = (t) => 2.0/Sqrt(PI) * Exp(-Pow(t, 2));
		Func<double, double> erf = (x) => o8a(f, 0, x);
		double eps = 1.0/64;
		for(double i=0+eps; i < 3; i += eps){
			WriteLine($"{i} {erf(i)}");
		}
	}
}

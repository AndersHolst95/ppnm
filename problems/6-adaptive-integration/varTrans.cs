using static System.Console;
using static System.Math;
using System;

public class varTrans{
	public static double CCVarTrans(Func<double, double> f, double a, double b, double del, double eps){

		// We need to rescale, so that the integral is going from -1 to 1
		// This is why we multiply by (a-b)/2 around?
		Func<double, double> g = (theta) => f((a+b)/2 + (b-a)/2 * Cos(theta)) * Sin(theta) * (b-a)/2;
		return recAdapt.integrate(g, 0, PI, del, eps);
	}

	public static double integrate(Func<double, double> f, double a, double b, double del, double eps){
		double posinf = double.PositiveInfinity;
		double neginf = double.NegativeInfinity;
		if(b < a)
			return -integrate(f, b, a, del, eps);

		if(a == neginf && b == posinf){
			Func<double, double> g = (t) => f(t/(1 - t*t)) * (1 + t*t) / (Pow(1 - t*t, 2));
			return CCVarTrans(g, -1, 1, del, eps);
		}

		if(a != neginf && b == posinf){
			Func<double, double> g = (t) => f(a + t / (1 - t)) * 1.0 / Pow(1 - t, 2); 
			return CCVarTrans(g, 0, 1, del, eps);
		}

		if(a == neginf && b != posinf){
			Func<double, double> g = (t) => f(b + t / (1 +t)) * 1.0 / Pow(1 + t, 2);
			return CCVarTrans(g, -1, 0, del, eps);
		}

		return CCVarTrans(f, a, b, del, eps);
	}
}

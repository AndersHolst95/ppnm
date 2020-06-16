using static System.Console;
using static System.Math;
using System;

public class recAdapt{
	public static double integrator(Func<double, double> f, double a, double b, double del, double eps, double f2, double f3){
		double f1 = f(a + (b - a)/6);
		double f4 = f(a + (b - a) * 5/6);

		double Q = (2 * f1 + f2 + f3 + 2 * f4) / 6 * (b - a);
		double q = (f1 + f2 + f3 +f4) / 4 * (b - a);
		double err = Abs(Q - q);
		double tol = del + eps * Abs(Q);
		if(err < tol)
			return Q;
		else{
			double Q1 = integrator(f, a, (a+b)/2, del/Sqrt(2), eps, f1, f2);
			double Q2 = integrator(f, (a+b)/2, b, del/Sqrt(2), eps, f3, f4);
			return Q1 + Q2;
		}
	}

	public static double integrate(Func<double, double> f, double a, double b, double del, double eps){
		double f2 = f(a + (b - a) * 2/6);
		double f3 = f(a + (b - a) * 4/6);
		return integrator(f, a, b, del, eps, f2, f3);
	
	}
}

using static System.Console;
using static System.Math;
using System;
using System.IO;

public class main{
	public static void Main(){

		WriteLine("----- Problem A -----");
		// Function to find the root of. It should be pi
		Func<vector, vector> sin2 = (x) => new vector((Sin(x[0]) * Sin(x[0])));
		// Starting point, just a bit below pi
		vector x0 = new vector(3.0);
		// Finding the roots
		vector root = roots.newton(sin2, x0);
		double exp = PI;
		WriteLine("Small tests to make sure the root finder works:");
		WriteLine($"Looking for the root of Sin(x)^2 starting at {x0[0]:F3}");
		WriteLine($"Found root: 	{root[0]:F3}");
		WriteLine($"Expected value:	{exp:F3}");
		WriteLine($"Value at root: 	{sin2(root)[0]:F7}");

		WriteLine("");
		Func<vector, vector> g = x => new vector((4 - x[0]) * (6 - x[0]), (x[1] - x[0]) * (x[1] - 3));
		x0 = new vector(0, 0);
		root = roots.newton(g, x0);
		WriteLine($"Looking for roots for the function (4 - x)*(6 - x), (y - x)*(y - 3) starting at {x0[0]:F3}");
		WriteLine($"Found first root:	{root[0]:F3}");
		WriteLine($"Value at first root:	{g(root)[0]:F7}");
		WriteLine($"Found second root:	{root[1]:F3}");
		WriteLine($"Value at second root:	{g(root)[1]:F7}");

		WriteLine("");
		

		// Find the roots of the GRADIENT of Rosenbrock
		// The gradient:
		// 400x^3 - 400xy + 2x - 2, 200(y-x^2);
		// 
		WriteLine("The Rosenborck's vally function");
		Func<vector, vector> ros = delegate(vector  z){
			double x = z[0], y = z[1];
			return new vector(400  * Pow(x, 3) - 400 * x * y + 2*x - 2, 200*(y-x*x));
		};
		x0 = new vector(0, 0);
		root = roots.newton(ros, x0);
		WriteLine($"Found first root:	{root[0]:F3}");
		WriteLine($"Value at first root:	{ros(root)[0]:F7}");
		WriteLine($"Found second root:	{root[1]:F3}");
		WriteLine($"Value at second root:	{ros(root)[1]:F7}");


		WriteLine("");
		WriteLine("----- Problem B -----");
		double 	rmax = 8;
		Func<vector, vector> M = delegate(vector x) {
			double eps = x[0];
			double yrmax = f_eps(eps, rmax);
			return new vector(yrmax);
		};

		x0 = new vector(-1.0);
		root = roots.newton(M, x0);
		WriteLine($"with rmax = {rmax}, the energy is {root[0]}");
		using(StreamWriter hw = new StreamWriter("outHydro.txt")) {
			hw.WriteLine($"#r	f_eps		exact");
			for(double r = 0; r <= rmax; r +=rmax/100){
				hw.WriteLine($"{r} \t {f_eps(root[0], r)} \t {r*Exp(-r)}");
			}
		}
	}
		



		private static double f_eps(double eps, double r){
			double rmin = 1e-3; // as done in dmitris code
			Func<double, vector, vector> swave = delegate(double x, vector y){
			/*
			-f''/2 - (1/r)*f = f*eps
			f'' = -2*(1/r + eps)*f
			defining y0 = f
			defining y1 = f'
			y0' = y1
			y1' = -2*(-1/r + eps)*y0
			*/
			return new vector(y[1], -2*(1/x + eps) * y[0]);
			};
			vector frmin = new vector(rmin*(1 - rmin), 1 - 2*rmin);
			vector yrmax;
			(_, _, yrmax) = ode.driver(swave, rmin, frmin, r, 0.001);
			return yrmax[0];
		}
}

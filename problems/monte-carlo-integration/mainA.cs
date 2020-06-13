using static System.Math;
using static System.Console;
using System.IO;
using System;

public class mainA{
	public static void Main(){
		WriteLine("----- Problem A -----");
		WriteLine("Plain Monte Carlo");
		Func<vector, double> f = (x) => Cos(x[0]) * Cos(x[0]);
		vector a = new vector(0.0);
		vector b = new vector(PI);
		int N = 10000;
		double expected = PI / 2;
		(double res, _) = mcIntegrator.plainMC(f, a, b, N);
		WriteLine("Integrating cos(x)^2 from 0 to pi");
		WriteLine($"Expected:			{expected:F4}");
		WriteLine($"Result:				{res:F4}");
		WriteLine($"Derivation from expected:	{Abs(expected-res):F4}");

		WriteLine("Integrating (pi^3 * cos(x) * cos(y) * cos(z))^-1 (from 0 to pi)*3");
		f = delegate(vector v){
			double x = v[0];
			double y = v[1];
			double z = v[2];
			return Pow(PI * PI * PI * (1 - Cos(x) * Cos(y) * Cos(z)), -1);
		};
		expected = 1.3932039296856768591842462603255;
		a = new vector(0.0, 0.0, 0.0);
		b = new vector(PI, PI, PI);
		(res, _) = mcIntegrator.plainMC(f, a, b, N);
		WriteLine($"Expected:			{expected:F4}");
		WriteLine($"Result:				{res:F4}");
		WriteLine($"Derivation from expected:	{Abs(expected-res):F4}");


		WriteLine("\n----- Problem B -----");
		f = (x) => Cos(x[0]) * Cos(x[0]);
		a = new vector(0.0);
		b = new vector(PI);
		expected = PI / 2;
		int Nmin = 10;
		int Nmax = 10000;
		double err;
		using(StreamWriter bw = new StreamWriter("outDataB.txt")){
			for(N = Nmin; N < Nmax; N++){
				(_, err) = mcIntegrator.plainMC(f, a, b, N);
				bw.WriteLine($"{N} \t {err}");
			}
			
		}
		WriteLine("We want to check that the error of the plain Monte-Carlo method behaves as O(1/sqrt(N))");
		WriteLine("A plot showing this can be seen on figure \"plotB.svg\"");
		WriteLine("A small scaling factor of 1.1 has been multiplied to 1/sqrt(N)");
	}
}

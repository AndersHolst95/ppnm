using static System.Console;
using static System.Math;
using System;
using System.IO;
using System.Linq;

public class main{
	public static void Main(){
		WriteLine("----- Problem A -----");
		double eps = 1e-4;
		Func<vector, double> f = delegate(vector z){
			double x = z[0];
			double y = z[1];
			return Pow(1 - x, 2) + 100 * Pow(y - x*x, 2);
		};
		vector x0 = new vector(0, 0);
		vector expected = new vector(1.0, 1.0);
		vector minimum;
		int n = 0; // Steps
		(minimum, n) = minimization.qnewton(f, x0, eps);
		WriteLine("Finding minimas of Rosenbrok's vally function");
		WriteLine($"Expected minimas:	{expected[0]:F3}, {expected[1]:F3}");
		WriteLine($"Found minimas:		{minimum[0]:F3}, {minimum[1]:F3}");
		WriteLine($"Done in {n} steps");


		WriteLine($"\nFinding minimas of Himmelblau's function: ");
		n = 0;
		expected = new vector(3.0, 2.0);
		f = delegate(vector z){
			double x = z[0];
			double y = z[1];
			return Pow(x*x + y - 11, 2) + Pow(x + y*y - 7, 2);
		};
		(minimum, n) = minimization.qnewton(f, x0, eps);
		WriteLine("Finding minimas of Rosenbrok's vally function");
		WriteLine($"Expected minimas:	{expected[0]:F3}, {expected[1]:F3}");
		WriteLine($"Found minimas:		{minimum[0]:F3}, {minimum[1]:F3}");
		WriteLine($"Done in {n} steps");


		WriteLine("\n\n----- Problem B -----");
		// Maps every line in higgs to (x, y, z)
		var lines = File.ReadAllLines("higgs.txt").Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Select(line => new {x = double.Parse(line[0]), y = double.Parse(line[1]), z = double.Parse(line[2])}).ToList();
		
		int hlen = lines.Count();
		vector E = new vector(hlen);
		vector sig = new vector(hlen);
		vector err = new vector(hlen);
		for(int i = 0; i < hlen; i++){
			E[i] = lines[i].x;
			sig[i] = lines[i].y;
			err[i] = lines[i].z;
		}

		Func<double, double, double, double, double> breit = (e, m, g, a) =>
			a/(Pow(e - m, 2) + g*g/4);

		Func<vector, double> chi2 = delegate(vector z){
			double m = z[0];
			double gamma = z[1];
			double A = z[2];
			double sum = 0;
			for(int i = 0; i < hlen; i++){
				sum += Pow(breit(E[i], m, gamma, A) - sig[i], 2)/Pow(err[i], 2); // Why divided by err^2?
			}
			return sum;
		};


//Func<double, double, double, double, double> F = (e, m, g, a) => a/(Pow(e-m, 2) + g*g/4); // Breit-Wigner
//		Func<vector, double> chi2 = delegate(vector z) {
//			double m = z[0], gamma = z[1], A = z[2];
//			double sum = 0;
//			for (int i = 0; i < hlen; i++) {
//				sum += Pow(F(E[i], m, gamma, A) - sig[i], 2)/Pow(err[i], 2);
//			}
//			return sum;
//		};


		x0 = new vector(120, 2, 6);
		n = 0;
		(minimum, n) = minimization.qnewton(chi2, x0, eps);
		WriteLine("Fitting the Briet-Wigner function to the Higgs boson data");
		WriteLine("Found parameters:");
		WriteLine($"m:		{minimum[0]:F3}");
		WriteLine($"Gamma:		{minimum[1]:F3}");
		WriteLine($"A:		{minimum[2]:F3}");

	}
}

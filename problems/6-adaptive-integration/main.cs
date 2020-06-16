using static System.Console;
using static System.Math;
using System;

public class main{
	public static void Main() {
		// Usefull expressions
		double a = 0;
		double b = 1;
		double del = 1e-3;
		double eps = 1e-3;
		double res;
		double exact;
		double posinf = double.PositiveInfinity;
		double neginf = double.NegativeInfinity;
		Func<double, double> f;

		// Test of the integrator
		WriteLine("----- Problem A -----");
		WriteLine("Testing of basic integrals:");
		WriteLine($"Integration of sqrt(x) from 0 to 1:");
		f = (x) => Sqrt(x);
		res = recAdapt.integrate(f, a, b, del, eps);
		exact = 2.0/3;
		WriteLine($"My result: {res:F4}, exact: {exact:F4} \n");

		WriteLine("Integration of 4 * sqrt(1-x^2) from 0 to 1:");
		f = (x) => 4 * Sqrt(1- x * x);
		res = recAdapt.integrate(f, a, b, del, eps);
		exact = PI;
		WriteLine($"My result: {res:F4}, exact: {exact:F4} \n");
		

		WriteLine("----- Problem B -----");
		WriteLine("Integration of 1/sqrt(x) from 0 to 1 using the variable transformation:");
		f = (x) => 1.0 / Sqrt(x);
		res = varTrans.integrate(f, a, b, del, eps);
		exact = 2;
		WriteLine($"My result: {res:F4}, exact: {exact:F4} \n");


		double evals = 0;
		f = delegate(double x) {evals++;
			return 1.0/Sqrt(x);};
		res = recAdapt.integrate(f, a, b, del, eps);
		exact = 2;
		WriteLine("Checking evaluations for 1/sqrt(x) from 0 to 1:");
		WriteLine("using recursive adaptive integrator");
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}");
		WriteLine("Using variable transformation:");
		evals = 0;
		res = varTrans.integrate(f, a, b, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}\n");

		
		f = delegate(double x) {evals++;
			return Log(x) / Sqrt(x);};
		res = recAdapt.integrate(f, a, b, del, eps);
		exact = -4;
		WriteLine("Checking evaluations for ln(x)/sqrt(x) from 0 to 1:");
		WriteLine("using recursive adaptive integrator");
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}");
		WriteLine("Using variable transformation:");
		evals = 0;
		res = varTrans.integrate(f, a, b, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}\n");

		

		WriteLine("Comparing different methods to integrate 4*sqrt(1-x^2)");
		exact = PI;
		f = delegate(double x) {evals ++;
			return 4 * Sqrt(1 - x * x);};
		evals = 0;
		WriteLine($"using recursive adaptive integrator");
		res = recAdapt.integrate(f, a, b, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res}, exact = {exact}");
		
		evals = 0;
		WriteLine($"using variable transformation:");
		res = varTrans.integrate(f, a, b, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res}, exact = {exact}");

		evals = 0; 
		WriteLine($"using o8av:");
		res = quad.o8av(f, a, b, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res}, exact = {exact}\n");

		WriteLine("----- Problem C -----");
		exact = Sqrt(PI)/2;
		f = delegate(double x) {evals++;
			return Sqrt(x) * Exp(-x);};
		evals = 0;
		WriteLine("Solving sqrt(x)*exp(-x) from 0 to infinity:");
		WriteLine("using variable transformation:");
		res = varTrans.integrate(f, 0, posinf, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}");

		evals = 0;
		WriteLine($"using o8av:");
		res = quad.o8av(f, 0, posinf, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}\n");	

		exact = Sqrt(PI);
		f = delegate(double x) {evals++;
			return Exp(-Pow(x, 2));};
		evals = 0;
		WriteLine("Solving exp(-x^2) from -infinity to infinity:");
		WriteLine("using variable transformation:");
		res = varTrans.integrate(f, neginf, posinf, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}");

		evals = 0;
		WriteLine($"using o8av:");
		res = quad.o8av(f, neginf, posinf, del, eps);
		WriteLine($"# of evaluations = {evals}, result = {res:F4}, exact = {exact:F4}\n");	



	}
}

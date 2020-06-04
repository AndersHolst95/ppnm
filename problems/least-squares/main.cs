using System;
using static System.Math;
using static System.Console;
using System.IO;

public class main{
	public static void Main(){
		vector time = new vector(new double[] {1, 2, 3, 4, 6, 9, 10, 13, 15});
		vector A = new vector(new double[] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1});
		vector dA = new vector(A.size);
		dA = 0.05 * A;
		
		// Transform y = a*exp(-lambda * t) --> ln(y) = ln(a) - lambda*t
		for(int i = 0; i < A.size; i++) {
			dA[i] = dA[i] / A[i];
			A[i] = Log(A[i]);
		}

		Func<double, double>[] funcs = new Func<double, double>[] {x => 1, x => x};
		

		TextWriter dataWriter = Error;

		fit fitresult = qrfit.qrfitting(time, A, dA, funcs);
		vector cErrors = fitresult.getParamErrors();

		double a = Exp(fitresult.c[0]);
		double lambda = -fitresult.c[1];
		double aErr = cErrors[0];
		double lambdaErr = cErrors[1];
		
		fitresult.c.print("Parameters:");
		WriteLine($"Acording to these paramaters, a = {a} and lambda = {lambda}");
		WriteLine($"This gives a half life of {Log(2) / lambda} days");
		WriteLine($"The half life of Ra224 is actually 3.6319 days");
		WriteLine("");
		fitresult.cov.print("The covariance matrix:");
		cErrors.print("The errors are for the parameters are:");
		WriteLine($"The half life of Ra224 is then estimated to {Log(2) / lambda} +- {-Log(2)/Pow(lambda, 2) * lambdaErr}");

		for(double x = 0; x < 22; x += 1.0/16){
			dataWriter.WriteLine($"{x}	{Exp(fitresult.eval(x))}");
			TextWriter answerWriter = Out;
		}
	}
}

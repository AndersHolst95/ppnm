using static System.Console;
using static System.Math;
using System;

public class neural{
	public vector p; 				// Parameters
	public Func<double, double> f;	// Activation Function
	public Func<double, double> df;	// Differentiated Act. Func.
	public Func<double, double> If;	// Integrated Act. Func.
	public int n;					// Number of neurons



	public neural(int n, Func<double, double> f, Func<double, double> df, Func<double, double> If){
		this.n = n;
		this.f = f;
		this.df = df;
		this.If = If;
		this.p = new vector(3 * n);
	}
	
	// returns the output signal of the hidden neurons, for a given x
	public double output(double x){
		double sum = 0;
		for(int i = 0; i < n; i++){
			double a = p[3 * i + 0];
			double b = p[3 * i + 1];
			double w = p[3 * i + 2];
			sum += w * f((x-a) / b);
		}
		return sum;
	}

	public double outputDiff(double x){
		double sum = 0;
		for(int i = 0; i < n; i++){
			double a = p[3 * i + 0];
			double b = p[3 * i + 1];
			double w = p[3 * i + 2];
			sum += w/b * df((x-a) / b);
		}
		return sum;
	}

	public double outputInte(double x){
		double sum = 0;
		for(int i = 0; i < n; i++){
			double a = p[3 * i + 0];
			double b = p[3 * i + 1];
			double w = p[3 * i + 2];
			sum += b * w * If((x-a) / b);
		}
		return sum;
	}

	public void train(double[] xs, double[] ys){
		int calls = 0;
		Func<vector, double> deviation = delegate(vector q){ // The delta(p) Function specified in the assignemnt
			calls++;
			p = q;
			double sum = 0;
			for(int i = 0; i < xs.Length; i++){
				sum +=Pow(output(xs[i]) - ys[i], 2);
			}
			return sum / xs.Length;
		};

		(vector v, int steps) = minimization.qnewton(deviation, p, 1e-2);
		p = v;
	}


}

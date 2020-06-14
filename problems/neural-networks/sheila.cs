using System;
using static System.Math;
using static System.Console;
using static minimization;

public class sheila{
	private Func<double, double> f; //activation function
	private int n; // Number of hidden neurons
	public vector p; // Keeping the parameters a, b, w for each hidden neuron
	
	// Constructor
	public sheila(int n, Func<double, double> f){
		this.n = n;
		this.f = f;
		this.p = new vector(3*n);
	}

	public void train(double[]xs, double[] ys){	
		// The deviation function: delta(p)
		Func<vector, double> deviation = delegate(vector q){
			p = q;
			int m = xs.Length;
			double sum = 0;
			for(int i = 0; i < m; i++){
				sum += Pow(output(xs[i]) - ys[i], 2);
			}
			return sum/m;
		};

		// Minimizing the deviation function
		(vector v,_) = minimization.qnewton(deviation, p, 1e-2);
		p = v;
	}
	
	// Returns the sum of the output signal for all of the hidden neurons for a given x
	public double output(double x){
		double a, b, w, sum = 0;
		for(int i = 0; i< n; i++){
			a = p[3*i +0];
			b = p[3*i +1];
			w = p[3*i +2];
			sum += f((x-a)/b)*w; //output signal function
		}
		return sum;
	}
}


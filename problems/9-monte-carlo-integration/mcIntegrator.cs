using static System.Console;
using static System.Math;
using System;

public class mcIntegrator{
	private static Random rand = new Random();
	public static (double, double) plainMC(
	Func<vector, double> f, // Function to integrate
	vector a,				// Starting point
	vector b,				// End point
	int N){					// Number of sample points
		double V = 1.0;
		for(int i = 0; i < a.size; i++)
			V *= b[i] - a[i];

		double sum1 = 0;
		double sum2 = 0;
		for(int i = 0; i < N; i++){
			vector randx = randomx(a, b);
			double frandx = f(randx);
			sum1 += frandx;
			sum2 += frandx * frandx;
		}
		double mean = sum1/N;
		double sig = Sqrt(sum2/N - Pow(mean, 2)) / Sqrt(N);
		return (mean * V, sig * V);
	}


	
	public static vector randomx(vector a, vector b){
		vector x = new vector(a.size);
		for(int i = 0; i < a.size; i++){
		// For every point in a and b, generate a random number between them
			x[i] = a[i] + rand.NextDouble() * (b[i] - a[i]);
		}
		return x;
	}
	
}

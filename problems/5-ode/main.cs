using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

public class main{
	public static void Main(){
		Func<double, vector, vector> f = delegate(double x, vector y) {
			return new vector(y[1], -y[0]);
			};

		double a = 0;
		vector ya = new vector(0.0, 1.0);  // Starting conditions
		double b = 2*PI; // Endpoint
		double h = 0.01; // Step size
		double acc = 1e-3;
		double eps = 1e-3;
		List<double> xs;
		List<vector> ys;
		vector Y;
		(xs, ys, Y) = ode.driver(f, a, ya, b, h, acc, eps);
		
		for(int i = 0; i < xs.Count; i++){
			WriteLine($"{xs[i]} \t {ys[i][0]} \t {Sin(xs[i])} \t {ys[i][1]} \t {Cos(xs[i])}");
		}
	}
}

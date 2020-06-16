using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.IO;
public class sir{
	
	public static void Main(){
		double N = 5.8e6; 	// Population
		double Tr = 14; 	// Number of days to recover 
		double Tc = 2;		// Days between contacts... This is a guess
		double S0 = N;		// Number of susceptible people
		double I0 = 400;	// Number of people initially infected
		double R0 = 0.0; 	// Number of people recovered
		vector ya = new vector(S0, I0, R0);

		/*
		S' = -I*S / N*Tc
		I' = I*S / N*tc -I/Tc
		R' = I/Tr
		*/
		Func<double, vector, vector> f = delegate(double x, vector y){
			double dSdt = -(y[1] * y[0]) / (N * Tc);
			double dIdt = (y[1] * y[0]) / (N * Tc) - y[1]/Tr;
			double dRdt = y[1] / Tr;
			return new vector(dSdt, dIdt, dRdt);
		};
		double a = 0; 		// Start time
		double b = 150;		// End time
		double h = 0.1; 	// Step size
		double acc = 1e-3;
		double eps = 1e-3;
		List<double> xs;	// x values will be put here
		List<vector> ys;	// y values will be put here
		(xs, ys, _) = ode.driver(f, a, ya, b, h, acc, eps);
		
		for(int i = 0; i < xs.Count; i++){
			WriteLine($"{xs[i]} \t {ys[i][0]} \t {ys[i][1]} \t {ys[i][2]}");
		}
		
		// Now we all practice social distancing!

		double Tc_SD = 6; 	// Number if days between contact when practising Social Distancing
		Tc = Tc_SD;
		TextWriter socialWriter = Error;
		List<double> xs_SD;	// x values will be put here
		List<vector> ys_SD;	// y values will be put here
		(xs_SD, ys_SD, _) = ode.driver(f, a, ya, b, h, acc, eps);
		for(int i = 0; i < xs_SD.Count; i++) {
			socialWriter.WriteLine($"{xs_SD[i]} \t {ys_SD[i][1]}");
		}

	}
}

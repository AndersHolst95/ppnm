using static System.Math;
using static System.Console;
using System;
using System.Collections.Generic;
using System.Collections;

public class ode{

	public static (vector, vector) rkstep4(Func<double, vector, vector> f, double t, vector yt, double h){
		vector k0 = f(t, yt);
		vector k1 = f(t + 0.5 * h, yt + 0.5 * h * k0);
		vector k2 = f(t + 0.5 * h, yt + 0.5 * h * k1);
		vector k3 = f(t + h, yt + h * k2);
		vector k = k0/6 + k1/3 + k2/3 + k3/6;			// Equation 17
		vector yh = yt + h * k;							 
		vector err = (k - k2) * h;						
		return (yh, err);
	}


	public static (List<double>, List<vector>, vector) driver(Func<double, vector, vector> F, double a, vector y, double b, double h, double acc = 1e-6, double eps = 1e-6){
		List<double> xs = new List<double>();
		List<vector> ys = new List<vector>();
		int n = y.size;
		while(a < b){
			if(b < a + h) 	// The final step
				h = b-a;
			vector tau = new vector(n);
			(vector yh, vector err) = rkstep4(F, a, y, h);
			for(int i = 0; i < n; i++) {
				tau[i] = (eps * Abs(yh[i]) + acc) * Sqrt(h / (b - a)); // Equation 41
				if(err[i] == 0)
					err[i] = tau[i] / 4;   // As done in Dmitris code
			}

			double fac = Abs(tau[0] / err[0]);
			for(int i = 1; i < n; i++){
				fac = Min(fac, Abs(tau[i] / err[i]));
			}
			bool acceptableErr = true;
			for(int i = 0; i < n; i++){
				if (Abs(err[i]) > tau[i]){
					acceptableErr = false;
					break;
				}
			}
			
			if(acceptableErr) {
				a += h;
				y = yh;
				xs.Add(a);
				ys.Add(y);
			}
			double hupdate = h * Pow(fac, 0.25) * 0.95;
			h = hupdate;
		}
		return (xs, ys, y);
	}
}

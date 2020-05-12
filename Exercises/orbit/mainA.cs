using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
class main {
	public static void Main() {
		// y[0] = y
		// y[1] = y'
		// y'[1] = -y[0]
		// y'[0] = y[1]
		// y'(x) = y(x) * (1 - y(x))
		Func <double, vector, vector> f = delegate(double x, vector y){ 
			return new vector(y[0] * (1 - y[0]), 0);
		};
		int xa = 0;
		int xb = 3;
		vector ya = new vector(0.5, 0);
		List<double> xs = new List<double>();
		List<vector> ys = new List<vector>();
		ode.rk23(f, xa, ya, xb, xlist:xs, ylist:ys);
		List<double> expected = xs.Select(x => 1/(1+ Exp(-x))).ToList();		
		for (int i = 0; i < xs.Count; i++) {
			WriteLine($"{xs[i]} {ys[i][0]} {expected[i]}");
		}
	}
}

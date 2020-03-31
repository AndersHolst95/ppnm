using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;


class main{
	public static void Main(string[] args) {
		var parser = args.Select(s => s.Split('=')).ToDictionary(s => s[0], s => double.Parse(s[1]));
		double xa = parser["xa"];
		double xb = parser["xb"];
		double y0 = parser["y0"];
		double y1 = parser["y1"];
		double eps = parser["eps"];
		
		vector ya = new vector(y0, y1);
		// y0 = y[0]
		// y1 = y[1]
		// y0 = u
		// y1 = u'
		// y0' = y1
		// y1' = 1 - y0 + eps * y0 * y0
		Func<double, vector, vector> f = delegate(double x, vector y) {
			return new vector(y[1], 1 - y[0] + eps * y[0] * y[0]);
		};
		
		List<double> xs = new List<double>();
		List<vector> ys = new List<vector>();
		ode.rk23(f, xa, ya, xb, xlist:xs, ylist:ys);
		for (int i = 0; i < xs.Count; i++) {
			WriteLine($"{xs[i]} {ys[i][0]}");
		}
	}
}

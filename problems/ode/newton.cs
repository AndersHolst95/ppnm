using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System;

// A big thanks to Kristan Lytje for the help on this problem

public class newton{
	public static void Main(){

		Func<double, vector, vector> f = delegate(double x, vector y){
			vector r1 = new vector(new double[]{y[0], y[1]});
			vector r2 = new vector(new double[]{y[2], y[3]});
			vector r3 = new vector(new double[]{y[4], y[5]});

			double r12 = Pow((r2 - r1).norm(), 3);
			double r13 = Pow((r3 - r1).norm(), 3);
			double r23 = Pow((r3 - r2).norm(), 3);
			
			vector ddr1 = (r2 - r1) / r12 + (r3 - r1) / r13;
			vector ddr2 = (r1 - r2) / r12 + (r3 - r2) / r23;
			vector ddr3 = (r1 - r3) / r13 + (r2 - r3) / r23;

			vector res = new double[]{y[6], y[7], y[8], y[9], y[10], y[11], ddr1[0], ddr1[1], ddr2[0], ddr2[1], ddr3[0], ddr3[1]};
			return new vector(res);
		};

		
		double xs1 = -1.0024277970, xs2 = 0.0041695061, vs1 = 0.3489048974, vs2 = 0.5306305100;
		vector ya = new vector(new double[]{xs1, xs2, -xs1, -xs2, 0, 0, vs1, vs2, vs1, vs2, -2*vs1, -2*vs2});
		double a = 0;
		double b = 100;
		double acc = 1e-3;
		double eps = 1e-3;
		double h = 1e-3;

		(List<double> ts, List<vector> ys, _) = ode.driver(f, a, ya, b, h, acc, eps);
		for(int i = 0; i < ts.Count; i++){
			WriteLine($"{ts[i]} \t {ys[i][0]} \t {ys[i][1]} \t {ys[i][2]} \t {ys[i][3]}\t {ys[i][4]} \t {ys[i][5]} \n\n");
		}
	}
}

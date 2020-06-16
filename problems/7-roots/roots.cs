using static System.Console;
using static System.Math;
using System;

public class roots{
	public static vector newton(Func<vector, vector> f, vector x, double eps = 1e-3, double dx = 1e-7){
		vector fx = f(x);
		matrix J = jacobian(f, x, dx);
		matrix R = new matrix(J.size2, J.size2);
		gs.decomp(J, R);
		matrix B = gs.inverse(J, R);
		vector Dx = -B * f(x);
		vector root;
			//WriteLine(x[0]);	
			//WriteLine(fx.norm());
		double lambda = 1.0;
		while((f(x + lambda * Dx)).norm() > (1 - lambda/2) * fx.norm() && (lambda > 1.0/64)){
			lambda /= 2;
		}
		x = x + lambda * Dx;

		if(Dx.norm() < dx){
			root = x;
		}
		else if(f(x).norm() < eps) {
			root = x;
		}
		else{
			root = newton(f, x, eps, dx);
		}

		return root;
	}

	public static matrix jacobian(Func<vector, vector> f, vector x, double dx = 1e-7){
		int n = x.size;
		matrix J = new matrix(n, n);
		vector fx = f(x);
		vector df;
		for(int k = 0; k < n; k++){
			x[k] += dx;
			df = f(x) - fx;
			for(int i = 0; i < n; i++){
				J[i, k] = df[i]/dx;
			}
			x[k] -= dx;
		}
		return J;
	}


}

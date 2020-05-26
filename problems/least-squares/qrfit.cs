using System;
using static System.Console;
using static System.Math;


public class qrfit{
	public static fit qrfitting(vector x, vector y, vector dy, Func<double, double>[] funcs){
		int n = x.size, m = funcs.Length;
		matrix A = new matrix(n, m);
		matrix R = new matrix(m, m);
		vector b = new vector(n);

		for(int i = 0; i < n; i++){
			b[i] = y[i] / dy[i];
			for(int k = 0; k < m; k++){
				A[i, k] = funcs[k](x[i]) / dy[i];
			}
		}

		gs.decomp(A, R);
		vector c = gs.solve(A, R, b);

		matrix I = new matrix(m, m);
		I.set_identity();
		matrix Ri = gs.inverse(I, R);
		matrix cov = Ri * Ri.transpose();
		Ri.print("R inverse:");

		return new fit(c, funcs, cov);
	}
}

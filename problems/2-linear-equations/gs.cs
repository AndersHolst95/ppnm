using static System.Math;
using static System.Console;
using System;

public class gs{
	public static void decomp(matrix A, matrix R){
		int m = A.size2;
		for(int i = 0; i < m; i++){
			vector ai = A[i];
			R[i, i] = ai.norm();
			vector qi = ai / R[i, i];
			A[i] = qi;
			for(int j = i + 1; j < m; j++){
				vector aj = A[j];
				R[i, j] = qi.dot(aj);
				A[j] = aj - qi * R[i, j];
			}
		}
	}

	public static vector solve(matrix Q, matrix R, vector b){
		vector c = Q.transpose() * b;
		vector x = new vector(R.size1);
		for(int i = x.size - 1; i >= 0; i--){
		double l = 0;
			for(int k = i+1; k < x.size; k++){
				l += R[i,k] * x[k];
			}
			x[i] = (1 / R[i, i]) * (c[i] - l); 
		}
		return x;
	}
	
	public static matrix inverse(matrix Q, matrix R){
		int n = Q.size1;
		matrix A = new matrix(n, n);
		vector e = new vector(n);
		for(int i = 0; i < n; i++){
			e[i] = 1;
			A[i] = solve(Q, R, e);
			e[i] = 0;
		}
		return A;
	}
}

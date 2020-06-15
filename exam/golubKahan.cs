using static System.Console;
using static System.Math;
using System;
using System.Collections.Generic;
using System.Collections;

public class golubKahan{
	
	public static (matrix, matrix, matrix) bidiagonolize(matrix A){
		int n = A.size1;
		vector[] V = new vector[n];
		vector[] U = new vector[n];
		vector alpha = new vector(n);
		vector beta = new vector(n);
		

		// To setup the algorithm, we have to manually calculate the first iteration
		V[0] = new vector(n);
		V[0][0] = 1;			// v_0 = 1 

		U[0] = A * V[0];		// As specified in line 3
		alpha[0] = U[0].norm();	// As specified in line 4
		U[0] = U[0] / alpha[0];	// As specified in line 5
		V[1] = A.T * U[0] - alpha[0] * V[0];
		beta[0] = V[1].norm();
		V[1] = V[1] / beta[0];

		for(int k = 1; k < n - 1; k++){
			U[k] = A * V[k] - beta[k-1] * U[k-1];
			alpha[k] = U[k].norm();
			U[k] = U[k] / alpha[k];
			V[k +1] = A.T * U[k] - alpha[k] * V[k];
			beta[k] = V[k+1].norm();
			V[k+1] = V[k+1] / beta[k];
		}

		// A last iteration of U is needed
		U[n-1] = A * V[n-1] - beta[n-2] * U[n-2];
		alpha[n-1] = U[n-1].norm();
		U[n-1] = U[n-1] / alpha[n-1];

		matrix B = new matrix(n, n);
		for(int i = 0; i < n; i++){
			B[i, i] = alpha[i];
			if(i < n-1)
				B[i, i+1] = beta[i];
		}
		matrix Unew = createMatrix(U);
		matrix Vnew = createMatrix(V);
		return (B, Unew, Vnew);
	}
	

	/*
	This method solves Ax = c
	This method follows equation 2.4 from the book to perform backwards substitution
	

	A = UBV^T
	UBV^T * x = c
	U^TUBV^T * x = U^T * c  
	==>  BV^T * x = U^T * c

	y = V^T * x, 	b = U^T * c
	The following system can then be solved
	By = b
	
	x can be obtained as
	V * y = x

	*/
	public static vector biDiagSolver(matrix B, vector c){
		int n = B.size1;
		vector y = new vector(n);
		y[n-1] = 1.0 / B[n-1, n-1] * c[n-1];
		for(int i = n - 2; i >= 0; i--){
			y[i] = (1.0 / B[i, i]) * (c[i] - B[i, i+1] * y[i+1]);
		}
		return y;
	}


	public static vector solve(matrix A, vector c){
		int n = A.size1;
		(matrix B, matrix U, matrix V) = bidiagonolize(A);
		vector b = U.transpose() * c;
		vector y = biDiagSolver(B, b);
		vector x = V * y;
		return x;
	}


	public static matrix inverse(matrix A){
		int n = A.size1;
		matrix Ai = new matrix(n, n);
		vector c = new vector(n);
		for(int i = 0; i < n; i++){
			c[i] = 1;
			Ai[i] = solve(A, c);
			c[i] = 0;
		}
		return Ai;
	}


	public static matrix createMatrix(vector[] v){
		int n = v.Length;
		matrix m = new matrix(n, n);
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < n; j++){
				m[i, j] = v[j][i];
			}
		}
		return m;
	}
}

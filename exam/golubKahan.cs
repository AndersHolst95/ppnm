using static System.Console;
using static System.Math;
using System;
using System.Collections.Generic;
using System.Collections;

/*
This class contains the methods:
bidiagonolize(matrix A)				returns bidiagonolized matrix B of A, U and V
biDiagSolver(matrix B, vector c)	Solves By = c, returns y
solve(matrix A, vector c)			Solves Ax = c, returns x
inverse(matrix A)					returns A^-1

The last three methods relies on the bidiagonolize method to perform their calculations.
*/
public class golubKahan{
	/*
	Runs the Golub-Kahan-Lanczos Bidiagonalization algirthm over a matrix A
	Returns the bidiagonolized matrix B and the calculated matrices U and V
	*/
	public static (matrix, matrix, matrix) bidiagonolize(matrix A){
		int n = A.size1;
		matrix B = new matrix(n, n);	// The matrix B
		matrix V = new matrix(n, n);	// The matrix V 
		matrix U = new matrix(n, n);	// The matrix U  
		vector alpha = new vector(n);	// The vector containing all alpha's
		vector beta = new vector(n);	// The vector containing all beta's

		V[0][0] = 1;			// We require that v_0 is the unit 2 norm vector. Therefore we put the first entry in v_0 to 1
		// A loop that runs throung the length of A, -1
		for(int k = 0; k < n - 1; k++){	
			if(k == 0){					// In the first iteration, we require that beta[-1] = 0, making the last term 0.
				U[0] = A * V[0];
			}
			else{						// The other iterations run with the last term
				U[k] = A * V[k] - beta[k-1] * U[k-1];
			}
			alpha[k] = U[k].norm();
			U[k] = U[k] / alpha[k];
			V[k +1] = A.T * U[k] - alpha[k] * V[k];
			beta[k] = V[k+1].norm();
			V[k+1] = V[k+1] / beta[k];
		}

		// A last iteration of U is needed, since v[k+1] is out of bounds
		U[n-1] = A * V[n-1] - beta[n-2] * U[n-2];
		alpha[n-1] = U[n-1].norm();
		U[n-1] = U[n-1] / alpha[n-1];
		

		// Set the diagonal of B to the alpha's, and the offdiagonal to the beta's
		for(int i = 0; i < n; i++){
			B[i, i] = alpha[i];
			if(i < n-1)
				B[i, i+1] = beta[i];
		}
		return (B, U, V);
	}
	

	/*
	This method solves By = c
	This method follows equation 2.4 from the book to perform backwards substitution,
	where we utilize that most of the entries in B is 0.
	We dont need to sum, since everyting other than i and i+1 is zero
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


	/*
	This method solves the linear equation "A*x = c"
	This is done by bidiagonalizing A, obtaining B, U and V
	Then a can be found using: 
	A = UBV^T
	UBV^T * x = c
	U^TUBV^T * x = U^T * c  
	==>  BV^T * x = U^T * c

	y = V^T * x, 	b = U^T * c
	The following system can then be solved
	By = b
	
	and x is found as
	V * y = x
	*/
	public static vector solve(matrix A, vector c){
		int n = A.size1;
		(matrix B, matrix U, matrix V) = bidiagonolize(A);
		vector b = U.transpose() * c;
		vector y = biDiagSolver(B, b);
		vector x = V * y;
		return x;
	}
	

	/*
	This method takes the inverse of a square matrix A
	It creates a new matrix of size n x n
	and a vector of size n
	It then solves n linear equations 
	Ax_i = e_i
	where e_i is the unit vector in the i'th direction
	as specified in equation 2.44 in the book
	*/
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
}

using static System.Console;
using static System.Math;
using System;
using System.Collections.Generic;

public class main{
	public static void Main() {
		int n = 5;
		matrix A = myMatrixMethods.randMatrix(n, n);
		(matrix B, matrix U, matrix V) = golubKahan.bidiagonolize(A);
		vector c = myMatrixMethods.randVector(n);

		// Solve Ax = c
		vector x = golubKahan.solve(A, c);

		A.print("A:");
		x.print("x:");
		c.print("c:");
		vector Ax = A * x;
		Ax.print("Ax:");


		matrix Ai = golubKahan.inverse(A);
		matrix AiA = Ai * A;
		AiA.print("A inverse times A:");
	}
}

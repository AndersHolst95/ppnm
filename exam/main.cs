using static System.Console;
using static System.Math;
using System;
using System.Collections.Generic;

public class main{
	public static void Main() {
		int n = 5;
		// A random matrix that is used throughout the testing
		matrix A = myMatrixMethods.randMatrix(n, n);

		// A random vector that is used throughout the testing 
		vector c = myMatrixMethods.randVector(n);

		// B is the bidiagonalization of A, and U and V are the corresponding matrixes used to perform this bidiagonalization
		(matrix B, matrix U, matrix V) = golubKahan.bidiagonolize(A);


		// Solve Ax = c
		vector x = golubKahan.solve(A, c);
		vector Ax = A * x;

		// UBV^T
		matrix UBVT = U * B * V.T;

		// U^T * U
		matrix UTU = U.T * U;

		// V^T * V
		matrix VTV = V.T * V;

		// Solve Bx = c
		vector xb = golubKahan.biDiagSolver(B, c);
		vector Bx = B * xb;

		// The inverse of A
		matrix Ai = golubKahan.inverse(A);
		matrix AiA = Ai * A;

		// Here is some explaining text that describes and shows that the implementation works
		WriteLine("This document shows that the implementation of exam question number 7 is correcet.");
		WriteLine("The document and classes are made by:");
		WriteLine("Anders Holst Rasmussen");
		WriteLine("Student number:\n201606907\n\n");
		WriteLine("Implementation of the Golub-Kahan-Lanczos bidiagoalization:");
		A.print($"There exists a {n}x{n} matrix with random entries:\nA:");
		c.print($"And a random vector of size {n}:\nc:");
		WriteLine("");
		WriteLine("We can perform a bidiagonalization of A, and optaining the matrix");
		B.print("B:");
		WriteLine("The method to perform the bidiagonalization of A also returns the matrices U and V. ");
		U.print("U:");
		V.print("V:");
		WriteLine("To check that the bidiagonalization has been performed correctly, we can check weather \"U^T * U = I\", and \"V^T * V = I\"");
		UTU.print("U^T * U:");
		VTV.print("V^T * V:");
		WriteLine("And it is seen that this is the case.");
		WriteLine("We can also check that \"A = U*B*V^T\"");
		A.print("A:");
		UBVT.print("U*B*V^T:");
		WriteLine("It can be seen that this is also the case.\n\n");
		

		WriteLine("----- Bidiagonal solver -----");
		WriteLine("A method to solve the equation \"B * x = c\" has been implemented");
		WriteLine("This method takes a bidiagonal matrix B and a vector c, and finds the vector x");
		WriteLine("Solving for x using B and c we get");
		xb.print("x:");
		WriteLine("And see that Bx = c");
		Bx.print("B*x:");
		c.print("c:  ");
		WriteLine("\n");

		WriteLine("----- General solver using bidiagonalization -----");
		WriteLine("A method to solve a general equation \"A*x=c\" has been implemented");
		WriteLine("This method takes a given matrix A, and a given vector c");
		WriteLine("It then performs a bidiagonalization of A, and solves the equation \"B*y = U^T*c\", and obtains y");
		WriteLine("Where y = V^T*x");
		WriteLine("x is then found as x = V*y");
		x.print("x:");
		WriteLine("And see that Ax = c:");
		Ax.print("A*x:");
		c.print("c:  ");

		WriteLine("\n");
		WriteLine("----- Inverse of a matrix ------");
		WriteLine("The bidiagonalization can also be used to calculate the inverse of matrix A.");
		WriteLine("This is done by using the genrel solver");
		WriteLine("This gives the inverse of A as:");
		Ai.print("A^-1:");
		WriteLine("And we can check that this is correct by calculating \"A^-1 * A\", which should be equal to I");
		AiA.print("A^-1 * A:");





	}
}

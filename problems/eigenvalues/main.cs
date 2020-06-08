using System;
using static System.Console;
using static System.Math;
using System.IO;

public class main{
	public static void Main(string[] args){
		int n = 5;
		matrix A = myMatrixMethods.randMatrix(n, n);
		// Make A symetrical
		myMatrixMethods.mirrorLower(A);
		A.print($"A is a symetrical matrix of size {n}");
		matrix V = new matrix(n, n);
		vector e = new vector(n);
		
		int sweeps = jacobi.cyclic(A, V, e);
		//V.print("Eigenvectors for A:");
		
		matrix D = new matrix(n, n);
		for(int i = 0; i < n; i++)
			D[i, i] = e[i];
		D.print("The diagonal composition, D:");
		// Restore A to the original symetrical matrix
		myMatrixMethods.mirrorLower(A);
		matrix test = V.transpose() * A * V;
		test.print("Test that V^T * A * V = D");
		if(test.approx(D, 1e-5))
			WriteLine("V^T * A * V == D - Works as intended");
		else
			WriteLine("V^T * A * V != D - Not as intended! Try again!");

		WriteLine("");

		matrix test2 = V * D * V.transpose();
		test2.print("Test that V * D * V^T = A");
		if(test2.approx(A))
			WriteLine("V * D * V^T == A - Works as intended");
		else
			WriteLine("V * A * V^T != A - Not as intended! Try again!");
		
		WriteLine("");
		WriteLine("----- Particle in a box -----");

		// Generate a Hamiltonian
		n = 30;
		double s = 1.0/(n+1);
		matrix H = new matrix(n, n);
		for(int i = 0; i < n-1; i++){
			H[i, i] = -2;
			H[i, i+1] = 1;
			H[i+1, i] = 1;
		}
		H[n-1, n-1] = -2;
		H = -(n+1) * (n+1) * H;

		// Diagonolize H 
		V = new matrix(n, n);
		vector eigenvals = new vector(n);
		sweeps = 0; 
		sweeps = jacobi.cyclic(H, V, eigenvals);

		// Check that the eigenvalues are correct
		WriteLine("E_n \t calculated \t exact");
		for(int k = 0; k < n/3; k++){
			double exact = PI * PI * (k+1) * (k+1);
			double calculated = eigenvals[k];
			WriteLine($"E_{k} \t {calculated.ToString("F5")} \t {exact.ToString("F5")}");
		}

		// preparing data to be plotted
		using(StreamWriter sw = new StreamWriter("data.txt")){
			sw.WriteLine($"0 \t 0 \t 0 \t 0 \t 0 ");
			for(int i = 0; i < n; i++){
				sw.Write($"{(i + 1) * 1.0 / (n + 1)}");
				for(int j = 0; j < 4; j++)
					sw.Write($"\t {V[i, j]} ");
					sw.Write("\n");
			}
			sw.WriteLine($"1 \t 0 \t 0 \t 0 \t 0");
		}

	
		WriteLine("");
		WriteLine("");
		WriteLine("----- Problem B -----");
		n = 7;
		A = myMatrixMethods.randMatrix(n, n);
		myMatrixMethods.mirrorLower(A);
		A.print("Matrix A:");
		V = new matrix(n, n);
		e = new vector(n);
		jacobi.cyclic(A, V, e);
		e.print("Has the eigenvals:");

		myMatrixMethods.mirrorLower(A);
		int kLowest = 2;
		vector kLowestEigenvals = jacobi.kLowestEigen(A, V, e, kLowest);
		kLowestEigenvals.print($"The {kLowest} lowest eigenvals are:");
		
		

		myMatrixMethods.mirrorLower(A);
		int kHighest = 3;
		vector kHighestEigenvals = jacobi.kHighestEigen(A, V, e, kHighest);
		kHighestEigenvals.print($"The {kHighest} highest eigenvals are:");
	}
}

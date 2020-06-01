using System;
using static System.Math;
using static System.Console;
using System.Diagnostics;

public class timing{
	public static void Main(string[] args){
		Stopwatch sw = new Stopwatch();
		int n = 0;
		int k = 1;
		bool tf = false; // Testing flag, used when i dont want to wait on the big calculations
		if(tf)
			n = 10;
		else 
			n = 600;
		for(int i = 2; i <= n; i++){
			matrix A = myMatrixMethods.randMatrix(i, i);
			myMatrixMethods.mirrorLower(A);
			matrix V = new matrix(i, i);
			vector e = new vector(i);

			sw.Start();
			jacobi.cyclic(A, V, e);
			sw.Stop();
			double cyclicTime = sw.ElapsedTicks/10000.0;
			sw.Reset();

			myMatrixMethods.mirrorLower(A);
			sw.Start();
			jacobi.kLowestEigen(A, V, e, k);
			sw.Stop();
			double lowestTime = sw.ElapsedTicks/10000.0;
			sw.Reset();
			
			myMatrixMethods.mirrorLower(A);
			sw.Start();
			jacobi.kHighestEigen(A, V, e, k);
			sw.Stop();
			double highestTime = sw.ElapsedTicks/10000.0;
			sw.Reset();

			WriteLine($"{i} \t {cyclicTime} \t {lowestTime} \t {highestTime}");
			if(i >= 100)
				i += 30;
		}
	}
}

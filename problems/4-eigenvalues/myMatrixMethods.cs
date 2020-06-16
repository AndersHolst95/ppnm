using System;
using static System.Console;
using static System.Math;

public class myMatrixMethods{
	
	public static matrix randMatrix(int n, int m){
		var rand = new Random(1023);
		matrix M = new matrix(n, m);
		for(int i = 0; i < n; i++){
			for(int j = 0; j < m; j++){
				M[i, j] = rand.Next(0, 20);
			}
		}
		return M;
	}


	public static vector randVector(int n){
	var rand = new Random();
	vector v = new vector(n);
	for(int i = 0; i < n; i++)
		v[i] = rand.Next(0, 20);
	return v;
	}

	public static matrix mirrorLower(matrix M){
		int n = M.size1;
		int m = M.size2;
		for(int i = 0; i < n; i++){
			for(int j = i + 1; j < m; j++){
				M[i, j] = M[j, i];
			}
		}
		return M;
	}



}

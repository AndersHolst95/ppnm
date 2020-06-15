using System;
using static System.Console;
using static System.Math;

public class myMatrixMethods{
	
	public static matrix randMatrix(int n, int m){
		var rand = new Random();
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
}

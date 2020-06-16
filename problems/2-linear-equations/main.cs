using static System.Console;
using static System.Math;
using System;

public class main{
	static void Main(string[] args){
		WriteLine("----- Problem A -----");
		WriteLine("------- testing the decomp function --------");
		int n = 5, m = 3;
		matrix A = randMatrix(n, m);
		matrix R = new matrix(m, m);
		matrix Q = A.copy();
		A.print("QR-decomposition of the matrix A: ");
		gs.decomp(Q, R);
		R.print("The matrix R: ");
		matrix QTQ = Q.transpose() * Q;
		QTQ.print("Q^t * t: ");
		matrix QR = Q * R;
		QR.print("QR: ");
		if(QR.approx(A))
			WriteLine("QR = A - Works as intended!");
		else
			WriteLine("QR != A - This does not work as intended. Try again!");


		WriteLine("------- testing the solve function --------");
		n = 4;
		A = randMatrix(n, n);
		R = new matrix(n, n); 
		Q = A.copy();
		vector b = randVector(n);
		gs.decomp(Q, R);
//		Q.print("A:");
//		R.print("R:");
//		b.print("b:");
		vector x = gs.solve(Q, R, b);
		x.print("x:");
		vector Ax = A * x;
		if(Ax.approx(b))
			WriteLine("A * x == b - works as intended");
		else
			WriteLine("A * x != b - this is not as intended! Try again!");
		


		WriteLine("----- Problem B -----");
		WriteLine("------- testing the inverse function --------");
		n = 6;
		A = randMatrix(n, n);
		R = new matrix(n, n);
		Q = A.copy();
		gs.decomp(Q, R);
		matrix Ai = gs.inverse(Q, R);
		matrix AAi = A * Ai;
		AAi.print("A * Ai:");
		matrix I = new matrix(n, n);
		I.set_identity();
		if(I.approx(AAi))
			WriteLine("A * Ainverse is the identity! - this is as intended!");
		else
			WriteLine("A * Ainverse is not the identity! - this is not as intended! Try again!");
	
	}


	public static matrix randMatrix(int n, int m){
		var rand = new Random(123);
		matrix M = new matrix(n, m);
		for(int i = 0; i < n; i++) {
			for(int j = 0; j < m; j++){
				M[i, j] = rand.Next(0, 10);
			}
		}
		return M;
	}

	public static vector randVector(int n){
	var rand = new Random(456);
	vector v = new vector(n);
	for(int i = 0; i < n; i++)
		v[i] = rand.Next(0, 10);
	return v;
	}
}

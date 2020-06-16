using System;
using static System.Console;
using static System.Math;

public class jacobi{
	private static bool diagChanged;
	private static int sweeps;
	
	
	public static int backupMethod(matrix A, matrix V, vector e){
		
		// n is the size of the matrix
		int n = A.size1;
		
		// V is the identity matrix of size n
		V.set_identity();
		
		// e is the vector containing the diagonals of A
		for(int i = 0; i < n; i++)
			e[i] = A[i, i];
		
		// diagChanged is a variable that is the convergence criteria. It is true as the method starts
		diagChanged = true;

		// sweeps is a variable, that counts how many sweeps has been performed
		sweeps = 0;

		// The Jacobi rotation is performed here, we check for convergence at the start
		while(diagChanged){
			// increase the number of sweeps
			sweeps++;

			// Loop over all the elements in the upper triangular part of A
			for(int p = 0; p < n; p++){
				for(int q = p+1; q < n; q++){
					// set values of App and Aqq to be the original matrix A's A[p,p] and A[q, q]
					double App = e[p], Aqq = e[q];
					// set a variable Apq to be the value at A[p, q]
					double Apq = A[p, q];
					// calculate phi 
					//double phi = 0.5 * Atan((2 * Apq) / (Aqq - App));
					double phi = Atan2(2*Apq , Aqq - App)/2;
					// set c and s as to cos(phi) and sin(phi)
					double c = Cos(phi), s = Sin(phi);

					// Make new variables that is A'[p, p] and A'[q, q]
					double AppPrime = Pow(c, 2) * App - 2 * s * c * Apq + Pow(s, 2) * Aqq;
					double AqqPrime = Pow(s, 2) * App + 2 * s * c * Apq + Pow(c, 2) * Aqq;

					// Check if A'[p, p] is different from A[p, p], and if A'[q, q] is different from A[q, q]. This is the convergence criteria
					if(AppPrime != App || AqqPrime != Aqq){
						// Update the diagonal, which is stored in vector e
						e[p] = AppPrime;
						e[q] = AqqPrime;
						// set A[p, q] to zero
						A[p, q] = 0.0;

						// Loop from i=0 to p and change values
						for(int i = 0; i < p; i++){
							double Aip = A[i, p], Aiq = A[i, q];
							A[i, p] = c * Aip - s * Aiq;
							A[i, q] = s * Aip + c * Aiq;
						}

						// Loop from i=p to q and change values
						for(int i = p+1; i < q; i++){
							double Api = A[p, i], Aiq = A[i, q];
							A[p, i] = c * Api - s * Aiq;
							A[i, q] = s * Api + c * Aiq;
						}
						
						// Loop from i=q+1 to n and change values
						for(int i = q+1; i < n; i++){
							double Api = A[p, i], Aqi = A[q, i];
							A[p, i] = c * Api - s * Aqi;
							A[q, i] = s * Api + c * Aqi;
						}

						// Update the V matrix
						for(int i = 0; i < n; i++){
							double Vip = V[i, p], Viq = V[i, q];
							V[i, p] = c * Vip - s * Viq;
							V[i, q] = c * Viq + s * Vip;
						}

					}
					// If A'[p, p] and A'[q, q] did not change
					else diagChanged = false;


				}
			}
		}
		// Return how many sweeps where needed
		return sweeps;
	}








	public static int cyclic(matrix A, matrix V, vector e){
		
		// n is the size of the matrix
		int n = A.size1;
		
		// V is the identity matrix of size n
		V.set_identity();
		
		// e is the vector containing the diagonals of A
		for(int i = 0; i < n; i++)
			e[i] = A[i, i];
		
		// diagChanged is a variable that is the convergence criteria. It is true as the method starts
		diagChanged = true;

		// sweeps is a variable, that counts how many sweeps has been performed
		sweeps = 0;

		// The Jacobi rotation is performed here, we check for convergence at the start
		while(diagChanged) {
			for(int p = 0; p < n; p++){
				for(int q = p+1; q < n; q++){
					rotate(A, V, e, p, q, 1);
				}
			}
		}
		return sweeps;
	}
	
	public static vector kLowestEigen(matrix A, matrix V, vector e, int k){
		vector eigenvals = new vector(k);
		int n = A.size1;
		V.set_identity();
		double tol = 1e-6;
		for(int i = 0; i < n; i++)
			e[i] = A[i, i];
		sweeps = 0;
		for(int p = 0; p < k; p++){
			diagChanged = true;
			while(diagChanged){
//			for(int p = 0; p < k; p++){
				for(int q = p+1; q < n; q++){
					rotate(A, V, e, p, q, 1);
				}
				eigenvals[p] = e[p];
			}
		}
		return eigenvals;
	}

	public static vector kHighestEigen(matrix A, matrix V, vector e, int k){
		vector eigenvals = new vector(k);
		int n = A.size1;
		V.set_identity();
		for(int i = 0; i < n; i++)
			e[i] = A[i, i];
		diagChanged = true;
		sweeps = 0;
		while(diagChanged){
			for(int p = 0; p < k; p++){
				for(int q = p+1; q < n; q++){
					rotate(A, V, e, p, q, -1); // The minus 1 changes the angle of phi in the rotate method, this is how we achive the highest eigenvals
				}
				eigenvals[p] = e[p];
			}
		}
		return eigenvals;
	}


	public static void rotate(matrix A, matrix V, vector e, int p, int q, int r){
		int n = A.size1;
		// set values of App and Aqq to be the original matrix A's A[p,p] and A[q, q]
		double App = e[p], Aqq = e[q];
		// set a variable Apq to be the value at A[p, q]
		double Apq = A[p, q];
		// calculate phi 
		double phi = Atan2(r*2*Apq , r*Aqq - r*App)/2;
		// set c and s as to cos(phi) and sin(phi)
		double c = Cos(phi), s = Sin(phi);
		// Make new variables that is A'[p, p] and A'[q, q]
		double AppPrime = Pow(c, 2) * App - 2 * s * c * Apq + Pow(s, 2) * Aqq;
		double AqqPrime = Pow(s, 2) * App + 2 * s * c * Apq + Pow(c, 2) * Aqq;

		// Check if A'[p, p] is different from A[p, p], and if A'[q, q] is different from A[q, q]. This is the convergence criteria
		if(AppPrime != App || AqqPrime != Aqq){
			// Update the diagonal, which is stored in vector e
			e[p] = AppPrime;
			e[q] = AqqPrime;
			// set A[p, q] to zero
			A[p, q] = 0.0;

			// Loop from i=0 to p and change values
			for(int i = 0; i < p; i++){
				double Aip = A[i, p], Aiq = A[i, q];
				A[i, p] = c * Aip - s * Aiq;
				A[i, q] = s * Aip + c * Aiq;
			}

			// Loop from i=p to q and change values
			for(int i = p+1; i < q; i++){
				double Api = A[p, i], Aiq = A[i, q];
				A[p, i] = c * Api - s * Aiq;
				A[i, q] = s * Api + c * Aiq;
			}
						
			// Loop from i=q+1 to n and change values
			for(int i = q+1; i < n; i++){
				double Api = A[p, i], Aqi = A[q, i];
				A[p, i] = c * Api - s * Aqi;
				A[q, i] = s * Api + c * Aqi;
			}

			// Update the V matrix
			for(int i = 0; i < n; i++){
				double Vip = V[i, p], Viq = V[i, q];
				V[i, p] = c * Vip - s * Viq;
				V[i, q] = c * Viq + s * Vip;
	 		}
		}
		// If A'[p, p] and A'[q, q] did not change
		else diagChanged = false;
	}
}

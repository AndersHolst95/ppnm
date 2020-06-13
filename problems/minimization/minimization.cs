using System;
using static System.Console;
using static System.Math;

public class minimization{

	public static vector gradient(Func<vector, double> f, vector x, double dx = 1e-7){
		vector g = new vector(x.size); 
		double fx = f(x);
		for(int i = 0; i < x.size; i++){
			fx = f(x);
			x[i] += dx; 	// Increment 
			g[i] = (f(x) - fx) / dx;
			x[i] -= dx;		// Decrement again
		}
		return g;
	}

	public static (vector, int) qnewton(Func<vector, double> f, vector x0, double eps){
		int n = 0; 						// Number of steps
		vector x = x0.copy();			// Position vector
		vector s; 						// Position vector
		double fx = f(x); 				// Function value
		double fxs;						// Function value
		vector gx = gradient(f, x);		// Gradient vector
		vector gxs;						// Gradient vector
		double a = 1e-4;				// Alpha in Armijo condition
		matrix B = matrix.id(x.size);	// Inverse Hessian, initially set to the identity matrix
		while(eps < gx.norm()){ // The accuracy goal
			n++;
			vector Dx = -B*gx; // Equation 6
			double lambda = 1;
			s = lambda * Dx; // Equation 8
			fxs = f(x + s);
			while(!(fxs < fx + a * s.dot(gx))){	// Backtracking
				s = lambda * Dx; // Equation 8
				fxs = f(x + s);
				if(lambda < 1.0/Pow(2, 5)){
					B = matrix.id(x.size); // Reset B if lambda becomes to small
					break;
				}
				lambda /= 2; 	// Halve the step size
			}
			gxs = gradient(f, x + s);
			vector y = gxs - gx; // Statement after eq 12
			vector u = s - B*y;	 // Statement after eq 12
			double uty = u.dot(y); // Denominatior of eq 18
			if(Abs(uty) > eps) 		// Condition for eq 18
				B.update(u, u, 1/uty);	// SR1 update
				
			// Prepare for next iteration
			x = x + s;
			gx =  gxs;
			fx = fxs;
		}	
		return (x, n); // Return the vector x, and the number of steps taken

	}
}

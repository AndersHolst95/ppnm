using static System.Console;
using static System.Math;
using System;

public class interpolate{
	// Binary search function 
	public static int binarySearch(vector x, int l, int r, double z){
		int mid = l + (r-l)/2;
		if(l == r) return l-1;
		if(x[mid] > z) return binarySearch(x, l, mid, z);
		return binarySearch(x, mid+1, r, z);
	}

	
	public class linear{
		public static double spline(double[] x, double[] y, double z){
			int i = binarySearch(x, 0, x.Length, z);
			return y[i] + (y[i+1] - y[i])/(x[i+1] - x[i]) * (z - x[i]);
		}
		
		public static double integrate(double[] x, double[] y, double z){
			int i = binarySearch(x, 0, x.Length, z);
			double sum = 0, dx, pi;
			for(int j = 0; j < i ; j++){
				dx = x[j+1] - x[j];
				pi = (y[j+1] - y[j]) / dx;
				sum += 1.0/2 * pi * Pow(dx, 2) + y[j] * dx;
			}

			double dz = z - x[i];
			double p = (spline(x, y, z) - y[i]) / dz;
			sum += y[i] * dz + p/2 * Pow(dz, 2);
			return sum;
		}
	}


	public class quadratic{
		private double[] x, y, b, c;
		public quadratic(double[] x, double[] y){
			this.x = x;
			this.y = y;
			b = new double[x.Length];
			c = new double[x.Length];
			calc();
		}
		
		private void calc(){
			double[] cforward = new double[x.Length];
			double[] cback = new double[x.Length];
			double[] p = new double[x.Length];
			double[] dx = new double[x.Length];
			cforward[0] = 0;
			dx[0] = x[1] - x[0];
			p[0] = (y[1] - y[0]) / dx[0];

			for(int i = 1; i < x.Length - 1; i++) {
				dx[i] = x[i+1] - x[i];
				p[i] = (y[i+1] - y[i]) / dx[i];
				cforward[i] = 1.0/dx[i-1] * (p[i] - p[i-1] - cforward[i-1] * dx[i-1]);
			}

			for(int i = x.Length-2; 0 <= i; i--){
				cback[i] = 1.0/dx[i] * (p[i+1] - p[i] - cback[i+1] * dx[i+1]);
			}

			for(int i = 0; i < x.Length; i++){
				c[i] = (cforward[i] + cback[i]) / 2;
				b[i] = p[i] - dx[i]*c[i];
			}
		}
		
		public double spline(double z){
			int i = binarySearch(x, 0, x.Length, z);
			double something = y[i] + b[i] * (z - x[i]) + c[i] * Pow((z - x[i]), 2);
			return something;
		} 

		public double derivative(double z){
			int i = binarySearch(x, 0, x.Length, z);
			return b[i] + 2 * c[i] * (z - x[i]);
		}

		public double integral(double z){
			int i = binarySearch(x, 0, x.Length, z);
			double sum = 0;
			for(int j = 0; j < i; j++){
				double dx = x[i+1] - x[i];
				sum += y[j] * dx + 1.0/2 * b[j] * Pow(dx, 2) + 1.0/3 * c[j] * Pow(dx, 3);
			}
			double dz = z - x[i];
			sum += y[i] * dz + 1.0/2 * b[i] *Pow(dz, 2) + 1.0/3 * c[i] * Pow(dz, 3);
			return sum;
		}











	}
}

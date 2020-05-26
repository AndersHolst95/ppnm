using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(string[] args) {
		double[] x, y;
		x = new double[] {0, PI*0.25, PI*0.5, PI*0.75, PI};
		y = new double[x.Length]; 
		for(int i = 0; i < x.Length; i++)
			y[i] = Cos(x[i]);   		// y is cos(x)
		double z;
		int step = 5; //number of steps between two points
		interpolate.quadratic q = new interpolate.quadratic(x, y);
		for(int i = 0; i < x.Length - 1; i++){
			for(int j = 0; j < step; j++){
				z = x[i] + j*(x[i+1] - x[i]) / step;
				WriteLine($"{z} {q.spline(z)}	{Cos(z)}	{q.derivative(z)}	{-Sin(z)}	{q.integral(z)}	{Sin(z)}");
			}
		}
	}
}

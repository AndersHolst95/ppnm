using System;
using static System.Math;
using static System.Console;

class main{
	public static void Main(string[] args) {
		vector x = new vector(1, 2, 3);
		vector y = new vector(3, 6, 8);
		double z = 4;
		
		interpolate.linterp(x, y, z);
		interpolate.linterpInteg(x, y, z);
		
		WriteLine("This is working as intended!");
	}
}

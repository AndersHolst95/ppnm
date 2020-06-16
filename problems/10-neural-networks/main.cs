using static System.Console;
using static System.Math;
using System;
using System.IO;

public class main{
	public static void Main() {
		Func<double, double> act = (x) => x * Exp(-x*x); 	//Activation function is a gaussian wavepacket
		Func<double, double> dact = (x) => Exp(-x * x) * (1 - 2 * x * x); // Differentiated activation function
		Func<double, double> iact = (x) => -Exp(-x * x) / 2; // Integrated activation function
		Func<double, double> f = (x) => Sin(x); // Function to be fitted. I have just choosen a very simple sin(x)
		Func<double, double> df = (x) => Cos(x); // Differentiated f
		Func<double, double> If = (x) => -Cos(x); // Integrated f
		int n = 5; 	// Number of hidden neurons
		neural nn = new neural(n, act, dact, iact); 
		double a = 0;
		double b = 2 * PI;
		int xlen = 15;
		double[] xs = new double[xlen];
		double[] ys = new double[xlen];
		for(int i = 0; i < xlen; i++){
			xs[i] = a + (b-a) * i / (xlen - 1);	// Space the x evenly
			ys[i] = f(xs[i]);	
			WriteLine($"{xs[i]} \t {ys[i]} \t {df(xs[i])} \t {If(xs[i])}");
		}

		for(int i = 0; i < n; i++){
			nn.p[3 * i + 0] = a + i * (b-a) / (n-1);
			nn.p[3 * i + 1] = 1;
			nn.p[3 * i + 2] = 1;
		}

		nn.train(xs, ys);
		double offset = If(xs[0]) - nn.outputInte(xs[0]);
		using(StreamWriter nnw = new StreamWriter("nn.txt")){
			for(double d = a; d <= b; d += 1.0/64){
				nnw.WriteLine($"{d} \t {nn.output(d)} \t {nn.outputDiff(d)} \t {nn.outputInte(d) + offset}");
			}
			
		}

	}
}

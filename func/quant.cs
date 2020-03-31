using System;
using static System.Console;
using static System.Math;
using static quad;
public class quantum{
	public static void Main(){
		Func<double, Func<double, double>> gauss = (y) => {return (x) => Exp(-y * Pow(x, 2)); };

		Func<double, Func< double, double>> hamilton = (y) => {return (x) =>
		(((-Pow(y, 2) * Pow(x, 2)) / 2) + (y / 2) + (Pow(x, 2) / 2)) * Exp(-y * Pow(x, 2));
		};

		double a = double.PositiveInfinity;
		double b = double.NegativeInfinity;
	
		for(double i = 0.1; i <= 3; i += 0.1) {
			double result = o8av(hamilton(i), a, b) / o8av(gauss(i), a, b);
			WriteLine($"{i}, {result}");
		}
	}
}

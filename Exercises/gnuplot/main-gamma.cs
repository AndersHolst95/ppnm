using System;
using static System.Console;
using static math;
class mainGamma{
	public static void Main(){
		double eps = 1.0/32;
		double dx = 1.0/16;		
		for(double x = -5 + eps; x<5; x += dx){
			WriteLine($"{x,10:f3} {math.gamma(x), 15:f8}");
		}
	}
}

using System;
using static System.Console;
using static math;
class mainLnGamma{
	public static void Main(){
		double eps = 1.0/32;
		double dx = 1.0/16;		
		for(double x = 0 + eps; x<30; x += dx){
			WriteLine($"{x,10:f3} {math.lngamma(x), 15:f8}");
		}
	}
}

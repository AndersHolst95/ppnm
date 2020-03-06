using System;
using static System.Console;
using static System.Math;
class readcmdLine{
	static void Main(string[] args){
		WriteLine("From read-cmdLine");
		WriteLine("x, sin(x), cos(x)");
		foreach(string s in args){
			int x  = int.Parse(s);
			WriteLine($"{x}, {Sin(x)}, {Cos(x)} ");
		}
	}
}

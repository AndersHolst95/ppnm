using System;
using System.IO;

class stdin{
	static void Main(){
	TextReader stdin = Console.In;
	TextWriter stdout = Console.Out;
	TextWriter stderr = Console.Error;
	stdout.WriteLine("From read-stdin");
	stdout.WriteLine("x, sin(x), cos(x)");
	do{
		string s = stdin.ReadLine();
		if(s == null)break;
		string[] words = s.Split(' ', ',', '\t');
		foreach(var word in words){
			double x = double.Parse(word);
			stdout.WriteLine($"{x}, {Math.Sin(x)}, {Math.Cos(x)}");
		}
	}while(true);
	}
}

using System;
using static System.Console;
using static cmath;
using static complex;
class math{
	static int Main(){
		double s2 = sqrt(2);
		complex I = new complex(0, 1);
		complex ei = exp(I); 
		complex eipi = exp(I*Math.PI);		
		complex ipowi = cmath.pow(I, I);
		complex sini = cmath.sin(I);	
	
		WriteLine($"The squareroot of 2 is {s2}");
		WriteLine($"e to the power of i is {ei}");
		WriteLine($"e to the power of i*pi is {eipi}");	
		WriteLine($"i to the power of i is {ipowi}");
		WriteLine($"sin(i) is {sini})");
		WriteLine("---Everything is as expected---");
		



	return 0;
	}
}

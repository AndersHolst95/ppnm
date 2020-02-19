using System;
using static System.Console;
class main{
	public static int Main(){
	var v = new vector3d(1, 2, 3);
	var u = new vector3d(3, 4, 5);

	WriteLine($"{v} + {u} = {v+u}");
	WriteLine($"{v} - {u} = {v-u}");
	WriteLine($"{v} * {2} = {v*2}");
	WriteLine($"{2} * {v} = {2*v}");
	WriteLine($"{v} dot {u} = {v.dot_product(u)}");
	WriteLine($"{v} cross {u} = {v.cross_product(u)}");
	WriteLine($"The magnitude of the vector {v} is {vector3d.magnitude(v)}");
	WriteLine($"{v} / {2} = {v/2}");
	v.x = 9;
	WriteLine(v);
	return 0;
	}
}

using static System.Console;
using System;
class hello{
	static int Main(){
		string uname = Environment.UserName;
		WriteLine($"Hello, {uname}!");
		return 0;
	}
}

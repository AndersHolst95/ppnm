out.txt : read-cmdLine.exe input.txt Makefile read-stdin.exe
	mono read-cmdLine.exe $$(cat input.txt) >out.txt
	mono read-stdin.exe < input.txt >> out.txt
	


read-cmdLine.exe : read-cmdLine.cs
	mcs read-cmdLine.cs

read-stdin.exe: read-stdin.cs
	mcs read-stdin.cs

clean:
	rm --force *.exe out*

all: a.svg bi.svg
	

bi.svg: bi.gpi outBi.txt
	gnuplot $<

a.svg: a.gpi outA.txt
	gnuplot $<

outBi.txt: mainB.exe Makefile
	mono $< xa=0 xb=6.3 y0=1 eps=0 y1=0 > $@

outA.txt: mainA.exe
	mono $< > $@

mainA.exe: mainA.cs math.dll
	mcs $< -reference:math.dll $<

mainB.exe: mainB.cs math.dll
	mcs $< -reference:math.dll $<

math.dll: ode.cs vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm --force *.txt *.exe out* *.dll

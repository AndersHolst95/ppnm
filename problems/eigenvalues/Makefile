libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += myMatrixMethods.cs
src += jacobi.cs

all: out.txt box.svg
	(cd times; make)

box.svg: plot.gpi main.exe
	gnuplot $<

out.txt: main.exe
	mono $< > $@ 

main.exe: main.cs math.dll
	mcs $< -reference:math.dll 

math.dll: $(src)
	mcs $^ -target:library -out:$@

clean:
	rm --force *.dll *.exe *.txt *.svg

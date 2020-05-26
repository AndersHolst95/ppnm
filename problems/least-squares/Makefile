libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../linear-equations/gs.cs
src += fit.cs
src += qrfit.cs

all: plot.svg answer.txt out.txt

plot.svg: plot.gpi
	gnuplot plot.gpi

out.txt answer.txt: main.exe
	mono $< 2> $@ > answer.txt

main.exe: main.cs math.dll
	mcs -reference:math.dll $<

math.dll: $(src)
	mcs $^ -target:library -out:$@

clean:
	rm --force *.dll *.exe

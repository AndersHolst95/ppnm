libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../2-linear-equations/gs.cs
src += fit.cs
src += qrfit.cs

all: plot.svg Answer.txt out.txt

plot.svg: plot.gpi
	gnuplot plot.gpi

out.txt Answer.txt: main.exe
	mono $< 2> $@ > Answer.txt

main.exe: main.cs math.dll
	mcs -reference:math.dll $<

math.dll: $(src)
	mcs $^ -target:library -out:$@

clean: 
	rm --force *.dll *.exe *.svg

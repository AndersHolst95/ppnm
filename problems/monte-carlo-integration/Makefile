libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += mcIntegrator.cs

all: Answers.txt plotB.svg

plotB.svg: plotB.gpi outDataB.txt
	gnuplot $<

Answers.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll 

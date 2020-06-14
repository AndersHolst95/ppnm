libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../minimization/minimization.cs
src += neural.cs

all: Answers.txt plotA.svg

plotA.svg: plotA.gpi nn.txt
	gnuplot $<

Answers.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll *.txt

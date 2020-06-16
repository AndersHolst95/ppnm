libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../8-minimization/minimization.cs
src += neural.cs

all: plotAB.svg outA.txt

plotAB.svg: plotAB.gpi outA.txt nn.txt
	gnuplot $<

outA.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll *.txt

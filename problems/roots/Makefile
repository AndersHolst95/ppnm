libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../linear-equations/gs.cs
src += ../ode/ode.cs
src += roots.cs

all: outA.txt hydrogen.svg


hydrogen.svg: hydrogen.gpi outHydro.txt
	gnuplot $<

outA.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll 

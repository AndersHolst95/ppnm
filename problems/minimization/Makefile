libdir=../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../linear-equations/gs.cs
src += ../ode/ode.cs
src += minimization.cs

all: Answers.txt
	cat $< 

Answers.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll 

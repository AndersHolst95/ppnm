LIBDIR=../../Math
SRC := $(LIBDIR)/vector.cs
SRC += $(LIBDIR)/vector.cs
SRC += interpolate.cs 

all: linear.svg quadratic.svg 

linear.svg: linear.gpi linear.txt
	gnuplot $<

quadratic.svg: quadratic.gpi quadratic.txt
	gnuplot $<

linear.txt: linear.exe 
	mono $< > $@

quadratic.txt: quadratic.exe
		mono $< > $@

linear.exe: linear.cs math.dll
	mcs -reference:math.dll $<

quadratic.exe: quadratic.cs math.dll
	mcs -reference:math.dll $<

math.dll: $(SRC) 
	mcs $^ -target:library -out:$@

clean: 
	rm --force *.dll *.exe *.svg

LIBDIR=../../Math
SRC := $(LIBDIR)/vector.cs
SRC += $(LIBDIR)/vector.cs
SRC += interpolate.cs 

all: out.txt
	cat $<

out.txt: linear.exe 
	mono $< > $@

linear.exe: linear.cs math.dll
	mcs -reference:math.dll $<

math.dll: $(SRC) 
	mcs $^ -target:library -out:$@

clean: 
	rm --force *.dll *.exe *.svg

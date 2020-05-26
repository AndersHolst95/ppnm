LIBDIR=../../math
SRC := $(LIBDIR)/vector.cs
SRC += $(LIBDIR)/matrix.cs 
SRC += gs.cs

all: out.txt
	cat $<

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll
	mcs -reference:matrix.dll $<

matrix.dll: $(SRC)
	mcs $^ -target:library -out:$@
	
clean: 
	rm --force *.dll *.exe

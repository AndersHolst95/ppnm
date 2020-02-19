CSFLAGS = -warn:4 -optimize-
.PHONEY: all
all : out.txt
	cat out.txt

out.txt : epsilon.exe
	mono $< > $@

epsilon.exe : epsilon.cs cmath.dll
	mcs $< -reference:cmath.dll

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

.PHONEY : clean
clean:
	rm --force out.txt epsilon.exe

CSFLAGS = -optimize- -warn:4
.PHONEY : all
all : out.txt
	cat out.txt

out.txt : math.exe
	mono $< > $@

math.exe : math.cs cmath.dll
	mcs $< -reference:cmath.dll

cmath.dll : cmath.cs complex.cs
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

.PHONEY : clean
clean:
	rm --force $< $@

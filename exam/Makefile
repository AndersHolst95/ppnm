libdir=libs
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += $(libdir)/myMatrixMethods.cs
src += golubKahan.cs

all: Answers.txt
	

Answers.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll *.txt

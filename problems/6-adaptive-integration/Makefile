libdir=../../math
src := $(libdir)/quado8.cs
src += recAdapt.cs
src += varTrans.cs

all: Answers.txt

Answers.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll 
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs -target:library -out:$@ $^ 

clean: 
	rm -f *.exe *.dll *.txt

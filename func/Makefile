all: out.txt quant.svg
	cat $<

quant.svg: quant.gpi outQuantum.txt
	gnuplot $<

out.txt: main.exe
	mono $< > $@

outQuantum.txt: quant.exe
	mono $< > $@

quant.exe: quant.cs quado8.dll
	mcs $< -reference:quado8.dll

main.exe: main.cs quado8.dll
	mcs $< -reference:quado8.dll

quado8.dll: quado8.cs
	mcs -target:library -out:$@ $<

clean:
	rm --force *.exe *.txt *.dll *.svg

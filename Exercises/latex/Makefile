all: error.pdf

error.pdf: error.tex plot.tex
	pdflatex $<
	pdflatex $<

plot.tex: plot.gpi out.txt tab-vals.txt
	gnuplot $<

out.txt: error.exe 
	mono $< > $@

error.exe: error.cs quado8.dll
	mcs -reference:quado8.dll $<

quado8.dll: quado8.cs
	mcs -target:library -out:$@ $<

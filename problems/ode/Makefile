libdir=../../math
src := $(libdir)/vector.cs
src += ode.cs

all: plotA.svg sirPlot.svg sirPlot_SD.svg newton.gif

plotA.svg: plotA.gpi outA.txt
	gnuplot $<

sirPlot.svg: sirPlot.gpi outSIR.txt outSIR_SD.txt
	gnuplot $<

sirPlot_SD.svg: sirPlot_SD.gpi outSIR.txt outSIR_SD.txt
	gnuplot $<

newton.gif: newton.gpi outNewton.txt
	gnuplot $<

outNewton.txt: newton.exe
	mono $< > $@

outSIR.txt outSIR_SD.txt: sir.exe
	mono $< 2> outSIR_SD.txt > outSIR.txt

outA.txt: main.exe
	mono $< > $@

newton.exe: newton.cs math.dll
	mcs $< -reference:math.dll

sir.exe: sir.cs math.dll
	mcs $< -reference:math.dll

main.exe: main.cs math.dll
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs $^ -target:library -out:$@

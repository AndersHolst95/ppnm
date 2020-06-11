libdir=../../../math
src := $(libdir)/vector.cs
src += $(libdir)/matrix.cs
src += ../myMatrixMethods.cs
src += ../jacobi.cs

all: time.txt timeplot.svg timeHighLowPlot.svg

timeplot.svg: timeplot.gpi time.txt
	gnuplot $<

timeHighLowPlot.svg: timeHighLowPlot.gpi time.txt
	gnuplot $<
	
time.txt: time.exe
	mono $< > $@

time.exe: time.cs math.dll
	mcs $< -reference:math.dll

math.dll: $(src)
	mcs $^ -target:library -out:$@

clean:
	rm --force *.exe *.txt *.svg
	

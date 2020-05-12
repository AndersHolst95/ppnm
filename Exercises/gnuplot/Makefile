all: LnGamma.svg Gamma.svg Error.svg

LnGamma.svg: lnGammaPlot.gpi outLnGamma.txt lnGammaTable.txt
	gnuplot $<

Gamma.svg: gammaPlot.gpi outgamma.txt gammaTable.txt
	gnuplot $<

Error.svg: errorPlot.gpi outerror.txt errorTable.txt
	gnuplot $<

outLnGamma.txt: main-lngamma.exe
	mono $< > $@

outgamma.txt: main-gamma.exe
	mono $< > $@

outerror.txt: main-error.exe
	mono $< > $@

math.dll: error.cs 
	mcs $< -target:library -out:$@

main-error.exe: math.dll main-error.cs
	mcs main-error.cs -reference:math.dll

main-gamma.exe: main-gamma.cs math.dll
	mcs $< -reference:math.dll

main-lngamma.exe: main-lngamma.cs math.dll
	mcs $< -reference:math.dll

clean:
	rm --force *.svg *.exe *.dll 

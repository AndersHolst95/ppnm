Gamma.svg: gammaPlot.gpi outgamma.txt
	gnuplot $<

Error.svg: errorPlot.gpi outerror.txt
	gnuplot $<

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

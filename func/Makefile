all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs quado8.dll
	mcs $< -reference:quado8.dll

quado8.dll: quado8.cs
	mcs -target:library -out:$@ $<

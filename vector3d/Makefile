CSFLAGS = -optimize- -warn:4
.PHONEY : all
all : out.txt
	cat out.txt

out.txt : main.exe
	mono $< > $@

main.exe: main.cs vector3d.dll ivector3d.dll
	mcs -target:exe -out:$@ -reference:$(word 2,$^) -reference:ivector3d.dll $<

vector3d.dll: vector3d.cs ivector3d.dll
	mcs -reference:ivector3d.dll $< -target:library

ivector3d.dll : ivector3d.cs
	mcs $< -target:library

.PHONEY : clean
clean:
	rm --force out.txt main.exe

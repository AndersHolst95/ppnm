CSFLAGS = -warn:4 -optimize-
.PHONEY : all
all : out.txt
	cat out.txt
out.txt: hello.exe
	mono $< > $@
hello.exe : hello.cs
	mcs $(CSFLAGS) $<
clean:
	rm -f $@ $<


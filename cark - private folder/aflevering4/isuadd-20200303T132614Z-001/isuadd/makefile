out.txt: isuadd.spec isuadd.mic1 add.bc
	mic1 -f isuadd.spec isuadd.mic1 add.bc 22 22 # 2^32-1 = 4294967295

isuadd.mic1: isuadd.mal
	mic1-asm isuadd.mal isuadd.mic1

add.bc: add.j
	ijvm-asm -f isuadd.spec add.j add.bc 

clean: 
	rm -f *.bc *.mic1

all: cmp_swp
	./cmp_swp 4

cmp_swp: cmp_swp.c my_cmpr_swap.s
	gcc -pthread cmp_swp.c my_cmpr_swap.s -o cmp_swp 

clean: 
	rm --force *.o cmp_swp

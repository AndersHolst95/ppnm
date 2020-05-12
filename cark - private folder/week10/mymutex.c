#include "mymutex.h"

void init_my_mutex(my_mutex_t *mutex) {
	*mutex = 1;
}

void lock_my_mutex(my_mutex_t *mutex){
	asm("	movq $0, %%rax\n\t"
			"1: cmpq %%rax,(%%rdi)\n\t"
			"jz 1b\n\t"
			"xchg %%rax,(%%rdi)\n\t"
			"2: cmpq $0, %%rax\n\t"
			"jz 1b\n\t"
			"\n\t":::"rax", "rdi");
}


void unlock_my_mutex(my_mutex_t *mutex){
	*mutex = 1;
}

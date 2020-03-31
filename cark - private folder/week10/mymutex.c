#include "mymutex.h"

void init_my_mutex(my_mutex_t *mutex) {
	*mutex = 1;
}

void lock_my_mutex(my_mutex_t *mutex){
	asm("	movq $0, %%rax\n\t"
			"1: cmpq %%rax,%%rcx\n\t"
			"jz 1b\n\t"
			"xchg %%rax,%%rcx"
			"\n\t":::"rax", "rcx");
}


void unlock_my_mutex(my_mutex_t *mutex){
	*mutex = 1;
}

#include <stdlib.h>
#include <stdio.h>
#include <unistd.h>

int main() {
	char c;
	printf("Press ENTER to allocate some memory ...\n");
	read(1, &c, 1);
	int *A = malloc(sizeof(int) * 100 * 1000);
	void *endofData = sbrk(0);
	char *charArray = (char *)A;
	long size = (unsigned long)endofData-(unsigned long)A;
	printf("A: %p, endofData: %p, size (in hex): %lX\n",A,endofData,size);
	printf("Press ENTER to access our entire data chunk...\n");
	read(1, &c, 1);
	charArray[size] = 10;
	for (long i=0 ; i<size ; i++){
		charArray[i]++;
		}
	
}


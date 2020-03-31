#include <stdio.h>
#include <stdlib.h> 

void main() {
	typedef struct complex_st {
		int attr1;
		int attr2;
	} 
	complex_t;
	complex_t *A = malloc(sizeof(complex_t)*10);

	A[0].attr1 = 1;
	A[0].attr2 = 222;
	A[1].attr1 = 0x11223344;
	A[1].attr2 = 0;
	printf("Array A at address %p and its first object has attributes %d and %d.\n",A,A[0].attr1,A[0].attr2);

	complex_t *B = &A[1];
	printf("Array B at address %p and its first object has attributes %d and %d.\n",B,B[0].attr1,B[0].attr2);

	B[0].attr1++;
	B[0].attr2++;
	printf("Array A at address %p and its second object has attributes %d and %d.\n",A,A[1].attr1,A[1].attr2);
	int *C = (int *)A;
	printf("Array C at address %p.\n",C);
	printf("Four values at array C are: %d, %d, %d (in Hex: %x), and %d.\n",C[0],C[1],C[2],C[2],C[3]);
	
	char *D = (char *)A;
	printf("Array D at address %p.\n",D);
	printf("16 first values at array D are: %d",D[0]);
	for (int i=1; i<16 ; i++){
		printf(", %d", D[i]);
	}
	printf(".\n");
	printf("16 first values at array D are (in hex): %hhx",D[0]);
	for (int i=1; i<16 ; i++){
		printf(", %hhx", D[i]);
	}
	printf(".\n");


}

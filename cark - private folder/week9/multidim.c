#include <stdio.h>
#include <stdlib.h>

void main(){
	char c;
	read(1, &c, 1);
	int** matrix = malloc(sizeof(int*)*10);
	for (int i=0 ; i<10; i++){
		matrix[i] = malloc(sizeof(int)*10);
	}
	read(1, &c, 1);
	matrix[1][2] = 12;
}

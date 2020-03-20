#include <stdio.h>

int main() {
	// standard values
	char c = 'c';
	short s = 5;
	int i = 10;
	long l = 29;
	long long ll = 9223372036854775807;
	
	// Pointers to the values above
	char* cp = &c;
	short* sp = &s;
	int* ip = &i;
	long* lp = &l;
	long long* llp = &ll;
	
	// task 3, incrementing via pointer
	printf("i before is %d \n", i);
	*ip += 1;
	printf("i after is %d \n", i);

	printf("%c \n", *cp);
	printf("%hd \n", *sp);
	printf("%d \n", *ip);
	printf("%li \n", *lp);
	printf("%lli \n", *llp);
	
	printf("The size of a char is %lu, short is %lu, int is %lu, long is %lu and long long is %lu \n", sizeof(c), sizeof(s), sizeof(i), sizeof(l), sizeof(ll));
	
	// task 4, unsigned 
	unsigned int ui = -1;
	printf("The unsigned value of -1 is %u \n", ui);
	printf("The signed value of -1 is %d \n", ui);
	
	
	return 0;
}

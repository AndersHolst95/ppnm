#include <stdio.h>
#include <stdlib.h>


// Functions to get the process id and parent's process id.
// When we use the keyword 'extern' we are telling the C
// compiler that the functions can be found/linked later.
// So the compiler does not complain about not finding
// these functions in this code. 
extern int mygetpid();
extern int mygetppid();

// The main function. 
int main(int argc, char *argv[]){
    // We need to call mygetpid and mygetppid functions
    // and then print their output using printf
	int i = mygetpid();
	int s  =mygetppid();
	printf("mygetpid is %d, and mygetppid is %d \n", i, s);
}

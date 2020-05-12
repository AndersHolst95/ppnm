#include <pthread.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdio.h>

// C has no boolean type so we define it.
#define true 1
#define false 0
// We define a boolean to be of type 'short int'
typedef short bool;

// We will count prime numbers up to this value
// Start small for testing, then increase to make sure that 
// when computing with one thread the program takes about
// 10 seconds, otherwise, the noise in the time calculation
// might cancel out any meaningful pattern.
#define MAX 100000

int tnum; // The number of threads

// We will need to maintain the number of primes of a particular
// type.
typedef struct ptypes_st {
    int n1; 
    int n3; 
    int n7; 
    int n9; 
} ptypes_t;

/* Or you can do:
typedef struct ptypes_st {
    int types[4];
} ptypes_t;
*/


// Here we need to define another struct to make the 
// compare and swap work. 
// In particular, we need a struct that is a combination of a counter and ptypes_t* type.
// We need another global variable of that type.
//

typedef struct status{
	ptypes_t *ref; // counts p3, p7...
	long long num;
}status_t;

struct args{ 
	int v1; 
	int v2;  
};

// Now we define a global variable to store the sum and the number
// of primes.
// In the main function, we will allocate some memory to it and initialize
// it to 0.
ptypes_t *global_ptypes;
status_t *global_status;

// We will dynamically allocate an array of pthread_t objects
// Thus, "threads" will be an array of pthread_t objects.
pthread_t *threads;

// A rather slow way to test if a number is a prime 
// Don't change this function
bool isPrime(long n){
    if (n==1) return false;
    long test=2;
    while (test*test <= n) { 
        if (n%test == 0) return false;
        test++;
    }
    return true;
}

// An external function written in assembly that does 
// compare and swap for us.
//
// It accepts three parameters of some yet unknown type that need to be defined somewhere. 
// For the documentation of the function, see the assembly file.
// Remember to pay attention to the order by which the parameters are passed in System V ABI
extern int my_cmpr_swap(status_t *old, status_t *cur, status_t *mod);

void * thread_function(void * input){
    // Here we loop over all the integers in the range 1-MAX that are assigned
    // to us (the current thread). 
    // if we find a prime number i then we have to atomically
    // update the total number of prime numbers of particular type.
	status_t *local = malloc(sizeof(status_t));
	int n1=0, n3=0, n7=0, n9=0;
	ptypes_t *mobj = malloc(sizeof(ptypes_t));

	struct args* arg = (struct args*) input;
	int l = arg->v1; int u = arg->v2;
	for (long i = l; i <= u; i++){
		if(isPrime(i)){
			int mod = i%10;
			if(mod == 1)  n1 +=1;
			else if(mod ==3) n3 +=1;
			else if (mod ==7) n7 +=1;
			else if(mod ==9) n9 +=1;
		}
	}
	status_t *modified = malloc(sizeof(status_t));
	modified->ref = mobj; //  a pointer
	int t = true;
	while(t){
		local->num = global_status->num; // hopefully a copy
		local->ref = global_status->ref;
		mobj->n1 = n1 + local->ref->n1;
		mobj->n3 = n3 + local->ref->n3;
		mobj->n7 = n7 + local->ref->n7;
		mobj->n9 = n9 + local->ref->n9;
		modified->num = 1 + local->num;

		t = !my_cmpr_swap(local, global_status, modified);
	};
	free(arg);
	free(local->ref);
	free(local);
	free(modified);
}

long main(int argc, char **args){
    // Initialize the global variable
	global_ptypes = malloc(sizeof(ptypes_t));
    global_ptypes->n1 = 0;
    global_ptypes->n3 = 0;
    global_ptypes->n7 = 0;
    global_ptypes->n9 = 0;
	global_status = malloc(sizeof(status_t));
	global_status->num=0;
	global_status-> ref = global_ptypes;
	
    // Alternatively, you can cast global_ptypes into an integer array
    // and loop through it. e.g.,
    // int *int_arr = (int *) global_ptypes;
    // for (int j=0 ; j<sizeof(ptypes_t)/sizeof(int); j++) int_arr[j] = 0;

    if (argc != 2) {
      printf("You need to specify the number of threads.\n");
      exit(-1);
    }
    tnum=atoi(args[1]);
    if (tnum <1) tnum=1;
    // tnum is now the number of threads.

    // An array of threads.
    pthread_t * threads = malloc(tnum*sizeof(pthread_t));
    int i;
    for (i=0; i<tnum ; i++){
        // Spawn the i-th thread.
		struct args* arg = malloc(sizeof(struct args));
		arg->v1 = MAX/tnum*i;
		arg->v2 = MAX/tnum*(i+1);
        int code = pthread_create(&threads[i], NULL, thread_function, (void*) arg);
        if (code) {
            printf("Something went wrong, aborting. \n");
            exit(-1);
        }
    }
	
    // We need to wait for the threads to finish their work. 
    for (i=0; i<tnum; i++){
        pthread_join(threads[i], NULL);
    }
	free(threads);
    printf("The result was: \nn1 = %i \nn3 = %i \nn7 = %i \nn9 = %i \n", global_status->ref->n1, global_status->ref->n3, global_status->ref->n7, global_status->ref->n9);
	printf("Sum: %i \n", global_status->ref->n1 + global_status->ref->n3 + global_status->ref->n7+ global_status->ref->n9);
}
